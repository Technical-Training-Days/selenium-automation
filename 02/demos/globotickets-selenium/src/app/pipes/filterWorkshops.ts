import { Pipe, PipeTransform } from '@angular/core';
import { IWorkshop } from '../interfaces/IWorkshop';

@Pipe({
  name: 'filterWorkshops',
})
export class FilterWorkshops implements PipeTransform {
  transform(array: IWorkshop[]): IWorkshop[] {
    return array.filter(workshop => workshop.checked);
  }
}
