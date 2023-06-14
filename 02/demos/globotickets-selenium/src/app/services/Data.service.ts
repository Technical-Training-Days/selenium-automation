import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ILunchOption } from '../interfaces/ILunchOption';
import { ITicketConfiguration } from '../interfaces/ITicketConfiguration';
import { IPrice } from '../interfaces/IPrice';
import { IWorkshop } from '../interfaces/IWorkshop';

@Injectable({
  providedIn: 'root',
})
export class DataService {
  constructor(private http: HttpClient) {}

  getLunchOptions(): Observable<ILunchOption[]> {
    return this.http.get<ILunchOption[]>('api/lunchOptions.json');
  }

  getWorkshops(): Observable<IWorkshop[]> {
    return this.http.get<IWorkshop[]>('api/workshops.json');
  }

  getTicketPrice(): Observable<IPrice> {
    return this.http.get<IPrice>('api/ticketPrice.json');
  }
}
