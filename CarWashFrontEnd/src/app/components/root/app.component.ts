import { AuthenticationService } from './../../services/authentication.service';
import { Component } from '@angular/core';
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  currentUsername = "";

  constructor(private _authService: AuthenticationService, private route: ActivatedRoute) {
    this.route.params.subscribe(p => {
      if (localStorage.getItem('currentUser')) {
        this.currentUsername = JSON.parse(localStorage.getItem('currentUser')).username;
      }
    });
  }

  isLoggedIn() {
    if (localStorage.getItem('currentUser')) {
      return true;
    } else {
      return false;
    }
  }

  logOut() {
    this._authService.logout();
  }
}
