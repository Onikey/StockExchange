import { User } from './models/user.model';
import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';
import { Observable } from 'rxjs';
import { UserService } from './user.service';

@Injectable()
export class UserResolver implements Resolve<User> {

    constructor(private _service: UserService) { }
    resolve(): Observable<any> | Promise<any> | any {
        return this._service.getUser();
    }
}
