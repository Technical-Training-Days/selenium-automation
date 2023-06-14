import { Component, OnInit } from '@angular/core';
import { faCircleQuestion } from '@fortawesome/free-regular-svg-icons';
import { FormGroup, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { v4 as uuidv4 } from 'uuid';

import { ILunchOption } from './interfaces/ILunchOption';
import { ITicketConfiguration } from './interfaces/ITicketConfiguration';
import { DataService } from './services/Data.service';
import { IconProp } from '@fortawesome/fontawesome-svg-core';

@Component({
  selector: 'app-configure-ticket',
  templateUrl: './configure-ticket.component.html',
  styleUrls: ['./configure-ticket.component.css'],
})
export class ConfigureTicketComponent implements OnInit {
  ticketPrice: number = 0;
  lunchOptions: ILunchOption[] = [];
  defaultModel: ITicketConfiguration = {
    fullName: '',
    includeLunch: false,
    lunchOption: 0,
    workshops: [],
    numberOfDays: 1,
    photo: '',
    notes: '',
  };
  model: ITicketConfiguration = { ...this.defaultModel };
  ticketConfigurations: ITicketConfiguration[] = [];
  isOrderProcessing: boolean = false;
  faCircleQuestion = faCircleQuestion as IconProp;

  constructor(private dataService: DataService, private router: Router) {}

  ngOnInit(): void {
    this.dataService.getLunchOptions().subscribe(lunchOptions => {
      this.lunchOptions = lunchOptions;
    });

    this.dataService.getWorkshops().subscribe(workshops => {
      this.defaultModel.workshops = workshops;
      this.model.workshops = workshops;
    });

    this.dataService.getTicketPrice().subscribe(ticketPrice => {
      this.ticketPrice = ticketPrice.price;
    });
  }

  onFormReset(form: FormGroup) {
    this.dataService.getWorkshops().subscribe(workshops => {
      var model = {...this.defaultModel};
      model.workshops = workshops;
      form.reset(model);
      form.controls['fullName'].markAsDirty();
    });
  }

  calculateLunchPrice() {
    if (this.model.includeLunch && this.model.lunchOption) {
      return this.lunchOptions.filter(
        option => option.id === this.model.lunchOption
      )[0].price;
    }
    return 0;
  }

  calculateWorkshopsPrice() {
    return this.model.workshops.reduce((previousValue, currentValue) => {
      if (currentValue.checked) {
        return previousValue + currentValue.price;
      }
      return previousValue;
    }, 0);
  }

  calculateTotalConfigurationPrice() {
    return (
      this.ticketPrice * this.model.numberOfDays +
      this.calculateLunchPrice() +
      this.calculateWorkshopsPrice()
    );
  }

  onTicketAdd(form: FormGroup) {
    this.isOrderProcessing = true;
    if (!form.valid) {
      form.controls['fullName'].markAsDirty();
      this.isOrderProcessing = false;
      return;
    }

    const configuration: ITicketConfiguration = {
      ...this.model!,
      id: uuidv4(),
      totalPrice: this.calculateTotalConfigurationPrice(),
    };

    this.onFormReset(form);

    this.updateTicketConfigurations([...this.ticketConfigurations, configuration]);

    if(this.router.url.includes("show-alert")) {
      alert("The ticket has been added to the order.");
    }
    this.isOrderProcessing = false
  }

  updateTicketConfigurations(ticketConfigurations: ITicketConfiguration[]) {
    this.ticketConfigurations = ticketConfigurations;
  }

  navigateToTheSuccessPage() {
    this.router.navigate(['success'], {
      state: { ticketConfigurations: this.ticketConfigurations },
    });
  }

  order() {
    const timeout = this.router.url.includes("order-delay") ?  (Math.random() * (10000 - 5000) + 5000) : 0;
    if (this.ticketConfigurations.length) {
        this.isOrderProcessing = true;
        setTimeout(() => {
          this.isOrderProcessing = false;
          this.navigateToTheSuccessPage();
        }, timeout);
    }
  }
}
