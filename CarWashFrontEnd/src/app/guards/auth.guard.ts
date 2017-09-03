import { Router, CanActivate } from '@angular/router';
import { Injectable } from '@angular/core';

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(private _router: Router) { }

    canActivate() {
        if (localStorage.getItem('currentUser')) {
            return true;
        }

        this._router.navigate(['/login']);
        return false;
    }

}