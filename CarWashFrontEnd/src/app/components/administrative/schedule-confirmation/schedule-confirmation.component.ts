import { ReservationsService } from './../../../services/reservations.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-schedule-confirmation',
  templateUrl: './schedule-confirmation.component.html',
  styleUrls: ['./schedule-confirmation.component.css']
})
export class ScheduleConfirmationComponent implements OnInit {

  unconfirmedReservations;

  constructor(private _reservationsService: ReservationsService) {
    this._reservationsService.getUnconfirmed()
      .subscribe(res => this.unconfirmedReservations = res);
  }

  ngOnInit() {
  }

}
