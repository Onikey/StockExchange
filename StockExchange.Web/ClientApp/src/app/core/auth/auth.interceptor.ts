import { HttpInterceptor, HttpRequest, HttpHandler, HttpUserEvent, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { AuthService } from './auth.service';
import 'rxjs/add/operator/do';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

    constructor(private router: Router, private jwtHelper: JwtHelperService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (req.headers.get('No-Auth') === 'True') {
            return next.handle(req.clone());
        }

        if (this.jwtHelper.tokenGetter() != null) {
            const clonedreq = req.clone({
                headers: req.headers.set('Authorization', 'Bearer ' + this.jwtHelper.tokenGetter())
            });
            return next.handle(clonedreq)
                .do(
                    succ => { },
                    err => {
                        if (err.status === 401) {
                            this.router.navigateByUrl('/account/login');
                        }
                    }
                );
        } else {
            this.router.navigateByUrl('/account/login');
        }
    }
}
