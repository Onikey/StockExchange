import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Firm, Issue, Trade } from '../models';

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

    public createTrade(newTrade: TradeInsertion): Observable<any> {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        };

        return this.httpClient.post('http://localhost:52382/api/trade', newTrade, httpOptions)
            .pipe();
    }
}

export interface TradeInsertion {
    issueName: string;
    price: number;
    qty: number;
    initFirmName: string;
    initSettlePairName: string;
    initAction: string;
    initMemo?: string;
    confFirmName: string;
}
