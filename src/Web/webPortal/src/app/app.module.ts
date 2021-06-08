import { BrowserModule } from '@angular/platform-browser';
import { APP_INITIALIZER, NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialUiModule } from './core/material-ui/material-ui.module';
import { NavBarComponent } from './core/navigation/nav-bar/nav-bar.component';
import { PageLinkComponent } from './core/navigation/page-link/page-link.component';
import { NgImageSliderModule } from 'ng-image-slider';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { CoreModule } from './core/core.module';
import { NewsletterDialogComponent } from './components/dashboard/dialogs/newsletter-dialog/newsletter-dialog.component';
import { BookingComponent } from './components/booking/booking.component';
import { ContactUsComponent } from './components/contact-us/contact-us.component';
import { TreatmentsComponent } from './components/treatments/treatments.component';
import { SettingsProvider } from './services/settingsprovider';
import { DatePipe } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ConfirmationDialogComponent } from './components/booking/dialogs/confirmation-dialog/confirmation-dialog.component';
import { ReferenceSearchComponent } from './components/reference-search/reference-search.component';

@NgModule({
  declarations: [
    AppComponent, 
    NavBarComponent, 
    PageLinkComponent, 
    DashboardComponent, 
    NewsletterDialogComponent, 
    BookingComponent, ContactUsComponent, TreatmentsComponent, ConfirmationDialogComponent, ReferenceSearchComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    CoreModule,
    MaterialUiModule,
    NgImageSliderModule,
    HttpClientModule,
  ],
  entryComponents: [NewsletterDialogComponent],
  providers: [
    DatePipe,
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
