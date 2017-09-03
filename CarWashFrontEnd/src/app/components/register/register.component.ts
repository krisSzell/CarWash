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

  constructor(formBuilder: FormBuilder, private _authService: AuthenticationService) {
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
      .subscribe();
  }

}
