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
  selectedService = {};
  selectedDate = {};
  currentStep = "service";

  constructor(private _reservationService: ReservationService) { }

  ngOnInit() {
    this._reservationService.currentReservationState
      .subscribe(reservation => this.reservation = reservation);
  }

  selectDate($event) {
    this.selectedService = $event;
    console.log(this.selectedService);
    this.currentStep = "date";
  }

  confirm($event) {
    this.selectedDate = $event;
    console.log(this.selectedDate);
  }
}
