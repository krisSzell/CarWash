import { ReservationsService } from './../../services/reservations.service';
import { Reservation } from '../../models/reservation';
import { ReservationService } from './../../services/reservation.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-reservations',
  templateUrl: './reservations.component.html',
  styleUrls: ['./reservations.component.css']
})
export class ReservationsComponent implements OnInit {

  reservation: Reservation;

  constructor(private _reservationService: ReservationService,
    private _reservationsService: ReservationsService) { }

  ngOnInit() {
    this._reservationService.currentReservationState
      .subscribe(reservation => this.reservation = reservation);
  }

  confirm() {
    this._reservationsService.bookReservation(this.reservation)
      .subscribe();
  }
}
