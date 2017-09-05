import { ReservationsService } from './../../../services/reservations.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-staff-dashboard',
  templateUrl: './staff-dashboard.component.html',
  styleUrls: ['./staff-dashboard.component.css']
})
export class StaffDashboardComponent {

  confirmedReservations;
  unconfirmedReservations;

  constructor(private _reservationsService: ReservationsService) {
    this._reservationsService.getConfirmed()
      .subscribe(res => this.confirmedReservations = res,
      null,
      () => this._reservationsService.getUnconfirmed()
        .subscribe(res => this.unconfirmedReservations = res));
  }

  updateConfirmed() {
    this._reservationsService.getConfirmed()
      .subscribe(confirmed => this.confirmedReservations = confirmed);
  }
}
