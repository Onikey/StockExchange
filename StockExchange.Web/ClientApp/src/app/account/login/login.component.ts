import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

import { LoaderService } from './../../core/loader';

import { AuthService } from './../../core/auth';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public loginForm: FormGroup;
  public submitted = false;
  public wrongCredentials = false;

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private loaderService: LoaderService,
    private router: Router) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });

  }

  get f() { return this.loginForm.controls; }

  public onSubmit() {
    this.submitted = true;

    if (this.loginForm.invalid) {
      return;
    }

    this.loaderService.show();

    this.authService.login({
      email: this.loginForm.controls.email.value,
      password: this.loginForm.controls.password.value
    }).subscribe(res => {
      this.loaderService.hide();
      this.router.navigate(['/']);
    }, err => {
      this.loaderService.hide();
      this.wrongCredentials = true;
      this.submitted = false;
    });
  }

  public registration() {
    this.router.navigate(['/account/registration']);
  }
}
