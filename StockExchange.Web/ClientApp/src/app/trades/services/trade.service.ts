import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Firm, Issue } from '../models';

@Injectable()
export class TradeService {
    constructor(private httpClient: HttpClient) {
    }

    public getCurrentFirm(): Observable<Firm> {
        return this.httpClient.get<Firm>('http://localhost:52382/api/firms/current')
            .pipe();
    }

    public getFirms(): Observable<Firm[]> {
        return this.httpClient.get<Firm[]>('http://localhost:52382/api/firms')
            .pipe();
    }

    public getIssues(): Observable<Issue[]> {
        return this.httpClient.get<Issue[]>('http://localhost:52382/api/issues')
            .pipe();
    }
}
