import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConfigureTicketComponent } from './configure-ticket.component';
import { OrderComponent } from './order.component';

const routes: Routes = [
  { path: '', component: ConfigureTicketComponent },
  { path: 'order-delay', component: ConfigureTicketComponent },
  { path: 'show-alert', component: ConfigureTicketComponent },
  { path: 'success', component: OrderComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
