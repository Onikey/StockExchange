import { Component } from '@angular/core';
import {
    Event,
    ActivatedRoute,
    Router,
    NavigationStart,
    NavigationEnd,
    NavigationCancel,
    NavigationError
} from '@angular/router';

import { LoaderService } from './core/loader';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

    constructor(private router: Router, private loaderService: LoaderService) {
        this.router.events.subscribe((event: Event) => {
            this.navigationInterceptor(event);
        });
    }

    // Shows and hides the loading spinner during RouterEvent changes
    navigationInterceptor(event: Event): void {
        if (event instanceof NavigationStart) {
            this.loaderService.show();
        }
        if (event instanceof NavigationEnd) {
            this.loaderService.hide();
        }

        // Set loading state to false in both of the below events to hide the spinner in case a request fails
        if (event instanceof NavigationCancel) {
            this.loaderService.hide();
        }
        if (event instanceof NavigationError) {
            this.loaderService.hide();
        }
    }
}
