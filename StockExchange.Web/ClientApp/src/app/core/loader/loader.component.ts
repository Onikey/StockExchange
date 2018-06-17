import { Component, OnInit, OnDestroy } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
    selector: 'app-loader',
    template: `<div mat-dialog-content class="loader-content">
                   <mat-spinner color="primary"></mat-spinner>
               </div>`,
    styles: [`.loader-content {
        overflow: hidden;
    }`]
})
export class LoaderComponent implements OnInit {
    constructor() { }

    ngOnInit() { }
}
