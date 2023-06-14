import {
  Component,
  Input,
  ChangeDetectionStrategy,
  Output,
  EventEmitter,
} from '@angular/core';
import { ILunchOption } from './interfaces/ILunchOption';
import { ITicketConfiguration } from './interfaces/ITicketConfiguration';

@Component({
  selector: 'app-configuration-table',
  templateUrl: './configuration-table.component.html',
  styleUrls: ['./configuration-table.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ConfigurationTableComponent {
  @Input() isOrderProcessing: boolean = false;
  @Input() ticketConfigurations: ITicketConfiguration[] = [];
  @Input() lunchOptions: ILunchOption[] = [];
  @Input() ticketPrice: number = 0;
  @Output() updateTicketConfigurations = new EventEmitter<
    ITicketConfiguration[]
  >();

  removeConfiguration(id: string) {
    let confirmRemove = true;

    if (this.ticketConfigurations.length === 1) {
      confirmRemove = confirm("Are you sure you want to remove the last remaining ticket?");
    }

    if(confirmRemove) {
      this.ticketConfigurations = [
        ...this.ticketConfigurations.filter(
          configuration => configuration.id !== id
        ),
      ];
    }

    this.updateTicketConfigurations.emit(this.ticketConfigurations);
  }
}

