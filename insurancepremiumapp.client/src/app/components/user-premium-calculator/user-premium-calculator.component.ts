import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { noFutureMonthValidator } from '../../validators/commonValidators';
import { OccupationService } from '../../services/occupation/occupation.service';
import { Occupation } from '../../models/occupation';
import { UserPremiumService } from '../../services/userPremium/user-premium.service';
import { PremiumRequest } from '../../models/PremiumRequest';
import { distinctUntilChanged } from 'rxjs/operators';

@Component({
  selector: 'user-premium-calculator',
  templateUrl: './user-premium-calculator.component.html',
  styleUrls: ['./user-premium-calculator.component.css']
})
export class UserPremiumCalculatorComponent implements OnInit {

  premiumForm!: FormGroup;
  monthlyPremium: number | null = null;
  error = '';
  occupationsList: Occupation[] = [];

  constructor(private fb: FormBuilder, private occupationService: OccupationService, private userPremiumService: UserPremiumService) {
    this.loadOccupations();
  }

  ngOnInit(): void {
    this.premiumForm = this.fb.group({
      userName: ['', Validators.required],
      ageNextBirthday: ['', [Validators.required, Validators.min(1), Validators.max(99)]],
      dateOfBirth: ['', [Validators.required, Validators.pattern(/^\d{4}-(0[1-9]|1[0-2])$/), noFutureMonthValidator]],
      occupationId: ['', Validators.required],
      deathSumInsured: ['', [Validators.required, Validators.min(1000), Validators.max(100000000)]],
    });

    this.premiumForm.valueChanges.subscribe(() => this.monthlyPremium = null);

    this.premiumForm.get('occupationId')?.valueChanges.pipe(distinctUntilChanged()).subscribe((value) => {
      if (this.premiumForm.valid && value != '') {
        setTimeout(() => this.calculatePremium(), 0);
      }
    });
  }

  loadOccupations(): void {
    this.occupationService.getOccupations().subscribe(data => this.occupationsList = data);
  }

  resetForm(): void {
    this.premiumForm.reset({
      occupationId: ''
    });
    this.monthlyPremium = null;
    this.error = '';
  }

  calculatePremium(): void {
    // Mark all controls as touched to trigger validation messages
    Object.keys(this.premiumForm.controls).forEach(field => {
      const control = this.premiumForm.get(field);
      control?.markAsTouched({ onlySelf: true });
    });

    if (this.premiumForm.valid) {
      this.error = '';
      const { userName, ageNextBirthday, dateOfBirth, occupationId, deathSumInsured } = this.premiumForm.value;

      const selectedOccupation = this.occupationsList.find(o => o.id.toString() === occupationId);
      if (!selectedOccupation) {
        this.monthlyPremium = null;
        return;
      }

      const request: PremiumRequest = {
        userName: userName,
        age: ageNextBirthday,
        dateOfBirth: dateOfBirth,
        occupationId: selectedOccupation.id,
        deathSumInsured: deathSumInsured
      };

      this.userPremiumService.calculatePremium(request).subscribe({
        next: (response) => {
          this.monthlyPremium = response.monthlyPremium;
        },
        error: (err) => {
          this.error = 'Error calculating premium - Please try after Sometime..';
          console.error('Error calculating premium:', err);
          this.monthlyPremium = null;
        }
      });
    }
    else {
      this.monthlyPremium = null;
    }
  }
}
