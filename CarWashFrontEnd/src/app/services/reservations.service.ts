import { AuthenticationService } from './authentication.service';
import { Reservation } from '../models/reservation';
import { Http, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { Injectable } from '@angular/core';

@Injectable()
export class ReservationsService {

  url = "http://localhost:59028/api/reservations";

  headers = new Headers({
    'Content-Type': 'application/json',
    'Authorization': 'Bearer ' + this._authService.token
  });
  options = new RequestOptions({
    headers: this.headers,
    method: RequestMethod.Post
  });

  constructor(private _http: Http, private _authService: AuthenticationService) { }

  bookReservation(reservation: Reservation) {
    reservation.username = JSON.parse(localStorage.getItem('currentUser')).username;
    return this._http.post(this.url, JSON.stringify(reservation), this.options)
      .map(res => res.json());
  }

}
