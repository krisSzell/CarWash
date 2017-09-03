import { UserService } from './services/user.service';
import { AuthenticationService } from './services/authentication.service';
import { ReservationsService } from './services/reservations.service';
import { ReservationDatePipe } from './reservation-date.pipe';
import { ReservationService } from './services/reservation.service';
import { AppRoutingModule } from './app-routing.module';
import { ServicesService } from './services/services.service';
import { WorkDayPipe } from './components/select-date/work-day-description.pipe';
import { WorkDaysService } from './services/work-days.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './components/root/app.component';
import { SelectDateComponent } from './components/select-date/select-date.component';
import { HttpModule } from "@angular/http";
import { ServicesPickerComponent } from './components/services/services-picker/services-picker.component';
import { ReservationsComponent } from './components/reservations/reservations.component';

@NgModule({
  declarations: [
    AppComponent,
    SelectDateComponent,
    WorkDayPipe,
    ReservationDatePipe,
    ServicesPickerComponent,
    ReservationsComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    AppRoutingModule
  ],
  providers: [
    WorkDaysService,
    ServicesService,
    ReservationService,
    ReservationsService,
    AuthenticationService,
    UserService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
