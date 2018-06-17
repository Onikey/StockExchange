import { environment } from './../../../environments/environment';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { LogPublisher, LogConsole, LogWebApi } from './log-publishers';

// ****************************************************
// Logging Publishers Service Class
// ****************************************************
@Injectable()
export class LogPublishersService {
    constructor(private http: Http) {
        // Build publishers arrays
        this.buildPublishers();
    }

    // Public properties
    publishers: LogPublisher[] = [];

    // *************************
    // Public methods
    // *************************
    // Build publishers array
    buildPublishers(): void {
        // Create instance of LogConsole Class
        this.publishers.push(new LogConsole());

        if (environment.useLogWebApi) {
            // Create instance of LogWebApi Class
            this.publishers.push(new LogWebApi(this.http));
        }
    }
}
