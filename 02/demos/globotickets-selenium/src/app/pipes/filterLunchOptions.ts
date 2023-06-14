import { Pipe, PipeTransform } from '@angular/core';
import { ILunchOption } from '../interfaces/ILunchOption';

@Pipe({
  name: 'filterLunchOptions',
})
export class FilterLunchOptions implements PipeTransform {
  transform(array: ILunchOption[], optionId: number): ILunchOption[] {
    return array.filter(option => option.id === optionId);
  }
}
