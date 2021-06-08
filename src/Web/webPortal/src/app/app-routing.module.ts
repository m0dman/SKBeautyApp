import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BookingComponent } from './components/booking/booking.component';
import { ContactUsComponent } from './components/contact-us/contact-us.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ReferenceSearchComponent } from './components/reference-search/reference-search.component';
import { TreatmentsComponent } from './components/treatments/treatments.component';

const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent },
  { path: 'treatment', component: TreatmentsComponent },
  { path: 'booking', component: BookingComponent },
  { path: 'reference', component: ReferenceSearchComponent },
  { path: 'contact', component: ContactUsComponent },
  // '**' stands for wildcard, which means that if none of the routes above are triggered, then this one will be activated.
  { path: '**', redirectTo: 'dashboard', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {  relativeLinkResolution: 'legacy', useHash: false }, )],
  exports: [RouterModule],
})
export class AppRoutingModule { }
