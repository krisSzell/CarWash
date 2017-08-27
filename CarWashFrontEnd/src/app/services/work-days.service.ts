import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';

import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class WorkDaysService {

  url = "http://localhost:59028/api/workdays";

  headers = new Headers({
    'Content-Type': 'application/json'
  });
  options = new RequestOptions({
    headers: this.headers
  });

  constructor(private _http: Http) { }

  getWorkDays() {
    return this._http.get(this.url)
      .map(res => res.json());
  }
}
