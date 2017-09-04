import { User } from './../models/user';
import { Observable } from 'rxjs/Observable';
import { Http, Headers, Response, RequestMethod, RequestOptions, RequestOptionsArgs } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';

@Injectable()
export class AuthenticationService {

  private authUrl = "http://localhost:59028/token";
  private regUrl = "http://localhost:59028/api/account/register";
  public token: string;

  constructor(private _http: Http) {
    var currentUser = JSON.parse(localStorage.getItem('currentUser'));
    this.token = currentUser && currentUser.token;
  }

  register(user: User): Observable<User> {
    return this._http.post(this.regUrl,
      JSON.stringify(user),
      {
        headers: new Headers({
          'Content-type': 'application/json'
        }),
        method: RequestMethod.Post
      })
      .map(res => user);
  }

  login(email: string, password: string): Observable<boolean> {
    let options = {
      headers: new Headers({
        'Content-Type': 'application/x-www-form-urlencoded'
      })
    }
    let body = new URLSearchParams();
    body.set('grant_type', 'password');
    body.set('username', email);
    body.set('password', password);

    return this._http.post(this.authUrl,
      body.toString(),
      options)
      .map((res: Response) => {
        let token = res.json().access_token;
        if (token) {
          this.token = token;

          localStorage.setItem('currentUser', JSON.stringify({ username: email, token: token }));

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
