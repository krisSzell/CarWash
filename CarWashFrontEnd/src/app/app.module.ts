import { LogsService } from './services/logs.service';
import { AuthGuard } from './guards/auth.guard';
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
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { ScheduleConfirmationComponent } from './components/administrative/schedule-confirmation/schedule-confirmation.component';
import { StaffDashboardComponent } from './components/administrative/staff-dashboard/staff-dashboard.component';
import { ConfirmedReservationsComponent } from './components/administrative/confirmed-reservations/confirmed-reservations.component';
import { LogsComponent } from './components/administrative/logs/logs.component';

@NgModule({
  declarations: [
    AppComponent,
    SelectDateComponent,
    WorkDayPipe,
    ReservationDatePipe,
    ServicesPickerComponent,
    ReservationsComponent,
    LoginComponent,
    RegisterComponent,
    ScheduleConfirmationComponent,
    StaffDashboardComponent,
    ConfirmedReservationsComponent,
    LogsComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [
    WorkDaysService,
    ServicesService,
    ReservationService,
    ReservationsService,
    AuthenticationService,
    UserService,
    LogsService,
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
