import { Router } from '@angular/router';
import { AuthenticationService } from './../../services/authentication.service';
import { UsernameValidators } from './../../validators/user-name.validators';
import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  form: FormGroup;

  constructor(formBuilder: FormBuilder, private _authService: AuthenticationService, private _router: Router) {
    this.form = formBuilder.group({
      email: ['', Validators.compose([
        Validators.required,
        UsernameValidators.cannotContainSpace
      ])],
      password: ['', Validators.required]
    });
  }

  login() {
    this._authService.login(this.form.value.email, this.form.value.password)
      .subscribe(null, null, () => {
        window.location.reload();
        this._router.navigate(['']);
      });
  }
}
