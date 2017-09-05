import { AuthenticationService } from './authentication.service';
import { Reservation } from '../models/reservation';
import { Http, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { Injectable } from '@angular/core';

@Injectable()
export class LogsService {

  url = "http://localhost:59028/api/logs";

  headers = new Headers({
    'Content-Type': 'application/json',
    'Authorization': 'Bearer ' + this._authService.token
  });
  options = new RequestOptions({
    headers: this.headers,
    method: RequestMethod.Get
  });

  constructor(private _http: Http, private _authService: AuthenticationService) { }

  getAll() {
    return this._http.get(this.url, this.options)
      .map(res => res.json());
  }
}