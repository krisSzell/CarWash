import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import 'rxjs/add/operator/map';

import { AuthenticationService } from './authentication.service';
import { User } from './../models/user';

@Injectable()
export class UserService {

  private usersUrl = "http://localhost:59028/api/users";
  constructor(private _http: Http, private _authService: AuthenticationService) { }

  getUsers(): Observable<User[]> {
    let headers = new Headers({ 'Authorization': 'Bearer ' + this._authService.token });
    let options = new RequestOptions({ headers: headers });

    return this._http.get(this.usersUrl, options)
      .map((res: Response) => res.json());
  }
}
