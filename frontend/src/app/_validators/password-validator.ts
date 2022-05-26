import {
    AbstractControl,
    ValidatorFn,
  } from '@angular/forms';

export default class PasswordValidator {
    static mustMatch(controlName: string, matchingControlName: string) : ValidatorFn {
      return (formGroup: AbstractControl) => {
        const control = formGroup.get(controlName);
        const matchingControl = formGroup.get(matchingControlName);
  
        if (matchingControl?.errors && !matchingControl.errors['mustMatch']) {
          return null;
        }
  
        // set error on matchingControl if validation fails
        if (control?.value !== matchingControl?.value) {
          formGroup.get(matchingControlName)?.setErrors({ mustMatch: true });
          return { mustMatch: true };
        } else {
          return null;
        }
      };
    }
}
