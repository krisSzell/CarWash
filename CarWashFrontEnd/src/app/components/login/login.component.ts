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

  constructor(formBuilder: FormBuilder) {
    this.form = formBuilder.group({
      username: ['', Validators.compose([
        Validators.required,
        UsernameValidators.cannotContainSpace
      ])],
      password: ['', Validators.required]
    });
  }
  //form = new FormGroup({
  //    username: new FormControl('', Validators.required),
  //    password: new FormControl('', Validators.required)
  //});

  signup() {
    this.form.controls['username'].setErrors({
      invalidLogin: true
    });
    console.log(this.form.value);
  }
}
