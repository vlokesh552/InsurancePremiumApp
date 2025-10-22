import { AbstractControl, ValidationErrors } from '@angular/forms';

export function noFutureMonthValidator(control: AbstractControl): ValidationErrors | null {
  const value = control.value; // expected format "YYYY-MM"
  if (!value) return null;

  const currentDate = new Date();
  const currentYear = currentDate.getFullYear();
  const currentMonth = currentDate.getMonth() + 1; // 0-based in JS

  const [yearStr, monthStr] = value.split('-');
  const year = parseInt(yearStr, 10);
  const month = parseInt(monthStr, 10);

  if (year > currentYear || (year === currentYear && month > currentMonth)) {
    return { futureDate: true };
  }
  
  return null;
}