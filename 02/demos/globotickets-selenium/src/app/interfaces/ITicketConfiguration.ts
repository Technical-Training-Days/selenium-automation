import { IWorkshop } from './IWorkshop';
import { ILunchOption } from './ILunchOption';

export interface ITicketConfiguration {
  id?: string;
  fullName?: string;
  includeLunch: boolean;
  lunchOption: number;
  workshops: IWorkshop[];
  numberOfDays: number;
  notes: string;
  photo: string;
  totalPrice?: number;
}
