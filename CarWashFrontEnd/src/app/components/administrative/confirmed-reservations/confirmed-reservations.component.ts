import { ReservationsService } from './../../../services/reservations.service';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-confirmed-reservations',
  templateUrl: './confirmed-reservations.component.html',
  styleUrls: ['./confirmed-reservations.component.css']
})
export class ConfirmedReservationsComponent {

  @Input('reservations') confirmedReservations;

  constructor() {
  }
}
