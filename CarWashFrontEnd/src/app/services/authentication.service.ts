import { Observable } from 'rxjs/Observable';
import { Http, Headers, Response } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';

@Injectable()
export class AuthenticationService {

  private authUrl = "http://localhost:59028/api/authentication";
  public token: string;

  constructor(private _http: Http) {
    var currentUser = JSON.parse(localStorage.getItem('currentUser'));
    this.token = currentUser && currentUser.token;
  }

  login(email: string, password: string): Observable<boolean> {
    return this._http.post(this.authUrl, JSON.stringify({ email: email, password: password }))
      .map((res: Response) => {
        let token = res.json() && res.json().token;
        if (token) {
          this.token = token;

          localStorage.setItem('currentUser', JSON.stringify({ email: email, token: token }));

          return true;
        } else {
          return false;
        }
      })
  }

  logout(): void {
    this.token = null;
    localStorage.removeItem('currentUser');
  }

}
