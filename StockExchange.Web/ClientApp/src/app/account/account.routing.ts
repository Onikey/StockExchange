import { ModuleWithProviders } from '@angular/core';
import { RouterModule } from '@angular/router';

import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';

export const AccountRoutingModule: ModuleWithProviders = RouterModule.forChild([
    { path: 'registration', component: RegistrationComponent },
    { path: 'login', component: LoginComponent }
]);
