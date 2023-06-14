import { Pipe, PipeTransform } from '@angular/core';
import { ITicketConfiguration } from '../interfaces/ITicketConfiguration';

@Pipe({
  name: 'calculateTotalPrice',
})
export class CalculateTotalPrice implements PipeTransform {
  transform(array: ITicketConfiguration[]): number {
    if (array) {
      return array.reduce((previousValue, currentValue) => {
        return previousValue + currentValue.totalPrice!;
      }, 0);
    } else {
      return 0;
    }
  }
}
