import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatInputModule, MatCardModule } from '@angular/material';

import { AccountRoutingModule } from './user.routing';

import { InformationComponent } from './information/information.component';

@NgModule({
  imports: [
    CommonModule,
    MatInputModule,
    MatCardModule,
    AccountRoutingModule
  ],
  declarations: [InformationComponent]
})
export class UserModule { }
