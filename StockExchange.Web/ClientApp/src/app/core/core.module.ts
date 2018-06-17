import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { MatDialogModule } from '@angular/material/dialog';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { JwtModule } from '@auth0/angular-jwt';

import { AuthInterceptor } from './auth/auth.interceptor';
import { LoaderService } from './loader';
import { UserService, UserResolver, AuthService, AuthGuard } from './auth';
import { LogPublishersService, LogService } from './logging';

import { LoaderComponent } from './loader/loader.component';
import { HttpModule } from '@angular/http';


export function tokenGetter() {
    return localStorage.getItem('access_token');
}

@NgModule({
    imports: [
        CommonModule,
        HttpModule,
        MatProgressSpinnerModule,
        MatDialogModule,
        JwtModule.forRoot({
            config: {
                tokenGetter: tokenGetter,
                whitelistedDomains: ['localhost:4200'],
                blacklistedRoutes: ['localhost:4200/auth/']
            }
        })
    ],
    declarations: [
        LoaderComponent
    ],
    entryComponents: [
        LoaderComponent
    ],
    providers: [
        LogService,
        LogPublishersService,
        AuthService,
        AuthGuard,
        UserService,
        UserResolver,
        LoaderService,
        {
            provide: HTTP_INTERCEPTORS,
            useClass: AuthInterceptor,
            multi: true
        }
    ]
})

export class CoreModule { }
