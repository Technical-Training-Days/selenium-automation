import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app-routing.module';
import { ConfigureTicketComponent } from './configure-ticket.component';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { FilterWorkshops } from './pipes/filterWorkshops';
import { FilterLunchOptions } from './pipes/filterLunchOptions';
import { IntegerValidatorDirective } from './shared/integer.directive';
import { HttpClientModule } from '@angular/common/http';
import { OrderComponent } from './order.component';
import { ConfigurationTableComponent } from './configuration-table.component';
import { CalculateTotalPrice } from './pipes/calculateTotalPrice';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@NgModule({
  declarations: [
    AppComponent,
    ConfigureTicketComponent,
    OrderComponent,
    ConfigurationTableComponent,
    FilterWorkshops,
    FilterLunchOptions,
    CalculateTotalPrice,
    IntegerValidatorDirective,
  ],
  imports: [BrowserModule, AppRoutingModule, FormsModule, HttpClientModule, NgbModule, FontAwesomeModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
