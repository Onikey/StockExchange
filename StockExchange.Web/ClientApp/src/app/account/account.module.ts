import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { MatFormFieldModule, MatCardModule, MatButtonModule, MatDividerModule, MatInputModule } from '@angular/material';

import { AccountRoutingModule } from './account.routing';

import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatCardModule,
    MatDividerModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    AccountRoutingModule
  ],
  declarations: [LoginComponent, RegistrationComponent]
})
export class AccountModule { }
