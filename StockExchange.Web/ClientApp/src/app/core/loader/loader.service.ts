import { Injectable } from '@angular/core';
import { Subject } from 'rxjs/Subject';

import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { LoaderComponent } from './loader.component';

@Injectable()
export class LoaderService {
    private dialogRef: MatDialogRef<LoaderComponent, any> = null;

    constructor(private dialog: MatDialog) { }

    public show() {
        this.dialogRef = this.dialog.open(LoaderComponent, { disableClose: true, panelClass: 'spinner-dialog-container' });

    }

    public hide() {
        this.dialogRef.close();
        this.dialogRef._containerInstance.dispose();
    }
}
