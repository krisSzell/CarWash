import { Router } from '@angular/router';
import { AuthenticationService } from './../../services/authentication.service';
import { UsernameValidators } from './../../validators/user-name.validators';
import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  form: FormGroup;

  constructor(formBuilder: FormBuilder,
    private _authService: AuthenticationService,
    private _router: Router) {
    this.form = formBuilder.group({
      email: ['', Validators.required],
      name: ['', Validators.compose([
        Validators.required,
        UsernameValidators.cannotContainSpace
      ])],
      surename: ['', Validators.required],
      password: ['', Validators.required],
      confirmPassword: ['', Validators.required]
    });
  }

  signup() {
    this._authService.register(this.form.value)
      .subscribe(null,
      () => console.log("Couldnt register user"),
      () => this._authService.login(this.form.value.email, this.form.value.password)
        .subscribe(null, null, () => {
          window.location.reload();
          this._router.navigate(['']);
        })
      );
  };

}
