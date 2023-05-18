import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  public login_form: FormGroup;
  loading = false;
  submitted = false;

  constructor(fb: FormBuilder) {
    this.login_form = fb.group({
      name: ["", Validators.required]
    });
  }

  get f() { return this.login_form.controls; }

  onSubmit() {
    console.log()
  }
}
