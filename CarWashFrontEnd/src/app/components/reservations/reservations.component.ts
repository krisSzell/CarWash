import { Reservation } from './../../reservation';
import { ReservationService } from './../../services/reservation.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-reservations',
  templateUrl: './reservations.component.html',
  styleUrls: ['./reservations.component.css']
})
export class ReservationsComponent implements OnInit {

  reservation: Reservation;
  currentStep = "service";

  constructor(private _reservationService: ReservationService) { }

  ngOnInit() {
    this._reservationService.currentReservationState
      .subscribe(reservation => this.reservation = reservation);
  }

  confirm() {

  }
}
