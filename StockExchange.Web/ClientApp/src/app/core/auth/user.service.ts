import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import { map } from 'rxjs/operators';

import { User } from './models/user.model';

@Injectable()
export class UserService {
    private currentUser: User = null;

    constructor(private http: HttpClient) { }

    public getUser(): Observable<User> {
        if (this.currentUser === null) {
            return this.http.get<User>('/clients')
                .pipe(map(user => {
                    this.currentUser = user;
                    return user;
                }));
        } else {
            return Observable.of(this.currentUser);
        }
    }

    public clearUser() {
        this.currentUser = null;
    }
}
