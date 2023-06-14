import { Directive } from '@angular/core';
import {
  AbstractControl,
  NG_VALIDATORS,
  ValidationErrors,
  Validator,
} from '@angular/forms';

@Directive({
  selector: '[appIntegerInput]',
  providers: [
    {
      provide: NG_VALIDATORS,
      useExisting: IntegerValidatorDirective,
      multi: true,
    },
  ],
})
export class IntegerValidatorDirective implements Validator {
  validate(control: AbstractControl): ValidationErrors | null {
    if (isNaN(control.value)) {
      return { integerOnly: true };
    }

    if (control.value % 1) {
      return { integerOnly: true };
    }

    return null;
  }
}
