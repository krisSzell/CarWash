import { Reservation } from './../reservation';
import { Http, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { Injectable } from '@angular/core';

@Injectable()
export class ReservationsService {

  url = "http://localhost:59028/api/reservations";

  headers = new Headers({
    'Content-Type': 'application/json'
  });
  options = new RequestOptions({
    headers: this.headers,
    method: RequestMethod.Post
  });

  constructor(private _http: Http) { }

  bookReservation(reservation: Reservation) {
    return this._http.post(this.url, JSON.stringify(reservation), this.options)
      .map(res => res.json());
  }

}
