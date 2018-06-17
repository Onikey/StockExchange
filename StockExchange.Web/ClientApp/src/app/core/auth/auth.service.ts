import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { JwtHelperService } from '@auth0/angular-jwt';

import { ICredentials } from './models/credentials.model';
import { User } from './models/user.model';
import { map, catchError } from 'rxjs/operators';
import { Observable } from 'rxjs/internal/Observable';
import { LogService } from '../logging';
import { UserService } from './user.service';

@Injectable()
export class AuthService {
    constructor(
        private http: HttpClient,
        private logService: LogService,
        private jwtHelper: JwtHelperService,
        private userService: UserService) { }

    public login(credentials: ICredentials): Observable<any> {
        const reqHeader = new HttpHeaders({ 'No-Auth': 'True' });
        return this.http.post('/system/auth', JSON.stringify(credentials), { headers: reqHeader })
            .pipe(map((response: any) => {
                localStorage.setItem('access_token', response.token);
                return;
            }));
    }

    public logout() {
        this.userService.clearUser();
        return this.http.put('/system/oauth/end', {})
            .pipe(
                map(() => localStorage.removeItem('access_token')),
                catchError(err => {
                    localStorage.removeItem('access_token');
                    return this.handleError(err);
                }));
    }

    public createUser(user: User): Observable<any> {
        const reqHeader = new HttpHeaders({ 'No-Auth': 'True' });
        return this.http.post('/clients/create', JSON.stringify(user), { headers: reqHeader })
            .pipe();
    }

    public isAuthenticated(): boolean {
        const token = this.jwtHelper.tokenGetter();
        // Check whether the token is expired and return
        // true or false
        return !this.jwtHelper.isTokenExpired(token);
    }

    handleError(error: any) {
        if (error.message) {
            this.logService.fatal(error.message, JSON.stringify(error, Object.getOwnPropertyNames(error)));
        } else {
            this.logService.fatal(error);
        }

        return Observable.of();
    }
}
