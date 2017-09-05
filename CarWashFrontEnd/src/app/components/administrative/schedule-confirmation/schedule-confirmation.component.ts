import { ReservationsService } from './../../../services/reservations.service';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-schedule-confirmation',
  templateUrl: './schedule-confirmation.component.html',
  styleUrls: ['./schedule-confirmation.component.css']
})
export class ScheduleConfirmationComponent {

  @Input('reservations') unconfirmedReservations = [];
  @Output('confirmed') onConfirm: EventEmitter<any> = new EventEmitter();

  constructor(private _reservationsService: ReservationsService) { }

  confirmReservation(reservationId: number) {
    this._reservationsService.confirmReservation(reservationId)
      .subscribe(res => console.log(res),
      null,
      () => this._reservationsService.getUnconfirmed()
        .subscribe(reservation => {
          this.unconfirmedReservations = reservation;
          this.onConfirm.emit();
        }));
  }

  rejectReservation(reservationId: number) {
    this._reservationsService.rejectReservation(reservationId)
      .subscribe(res => console.log(res),
      null,
      () => this._reservationsService.getUnconfirmed()
        .subscribe(reservation => this.unconfirmedReservations = reservation));
  }
}
