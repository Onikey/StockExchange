import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { AuthService } from '../../core/auth';
import { LoaderService } from '../../core/loader';

import { PasswordValidation } from './password.validation';
@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  public regForm: FormGroup;
  public submitted = false;
  public wrongCredentials = false;

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private loaderService: LoaderService,
    private router: Router,
    private location: Location) { }

  ngOnInit() {
    this.regForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      organization: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', [Validators.required, Validators.minLength(6)]]
    }, {
        validator: PasswordValidation.MatchPassword
      });

  }

  get f() { return this.regForm.controls; }

  public onSubmit() {
    this.submitted = true;
    this.loaderService.show();

    if (this.regForm.invalid) {
      this.loaderService.hide();
      return;
    }


    this.authService.createUser({
      firstName: this.regForm.controls.firstName.value,
      surname: this.regForm.controls.lastName.value,
      orgName: this.regForm.controls.organization.value,
      email: this.regForm.controls.email.value,
      password: this.regForm.controls.password.value
    }).subscribe(res => {
      this.loaderService.hide();
      this.router.navigate(['/']);
    }, err => {
      this.loaderService.hide();
      this.wrongCredentials = true;
      this.submitted = false;
    });
  }

  public back() {
    this.location.back();
  }
}
