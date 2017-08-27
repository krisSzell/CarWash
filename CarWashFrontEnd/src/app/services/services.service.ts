import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';

import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class ServicesService {

  url = "http://localhost:59028/api/services";

  headers = new Headers({
    'Content-Type': 'application/json'
  });
  options = new RequestOptions({
    headers: this.headers
  });

  constructor(private _http: Http) { }

  getServices() {
    return this._http.get(this.url)
      .map(res => res.json());
  }
}
