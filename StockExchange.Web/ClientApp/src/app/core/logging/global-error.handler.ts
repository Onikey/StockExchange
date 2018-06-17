import { Injectable, ErrorHandler } from '@angular/core';

import { LogService } from './log.service';

@Injectable()
export class GlobalErrorHandler extends ErrorHandler {
    constructor(private logService: LogService) {
        super();
    }

    // TODO : No error message
    handleError(error: any) {
        if (error.message) {
            this.logService.fatal(error.message, JSON.stringify(error, Object.getOwnPropertyNames(error)));
        } else {
            this.logService.fatal(error);
        }
    }
}
