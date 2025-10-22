import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserPremiumCalculatorComponent } from './user-premium-calculator.component';

describe('UserPremiumCalculatorComponent', () => {
  let component: UserPremiumCalculatorComponent;
  let fixture: ComponentFixture<UserPremiumCalculatorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserPremiumCalculatorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UserPremiumCalculatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
