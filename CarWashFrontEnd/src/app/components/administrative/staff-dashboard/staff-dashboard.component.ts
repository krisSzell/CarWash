import { LogsService } from './../../../services/logs.service';
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
  logs;

  constructor(private _reservationsService: ReservationsService, private _logsService: LogsService) {
    this._reservationsService.getConfirmed()
      .subscribe(res => this.confirmedReservations = res,
      null,
      () => this._reservationsService.getUnconfirmed()
        .subscribe(res => this.unconfirmedReservations = res));

    this._logsService.getAll()
      .subscribe(res => this.logs = res);
  }

  updateConfirmed() {
    this._reservationsService.getConfirmed()
      .subscribe(confirmed => this.confirmedReservations = confirmed);

    this._logsService.getAll()
      .subscribe(res => this.logs = res);
  }
}
