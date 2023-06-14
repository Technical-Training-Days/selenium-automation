import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ITicketConfiguration } from './interfaces/ITicketConfiguration';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css'],
})
export class OrderComponent {
  ticketConfigurations: ITicketConfiguration[] = [];

  constructor(private router: Router) {
    this.ticketConfigurations =
      this.router.getCurrentNavigation()?.extras.state?.[
        'ticketConfigurations'
      ];
  }
}
