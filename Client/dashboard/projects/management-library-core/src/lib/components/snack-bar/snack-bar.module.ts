import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { SnackBarComponent } from './snack-bar.component';
import { SnackBarService } from './snack-bar.service';
import { MatSnackBarModule } from '@angular/material';

@NgModule({
  imports: [CommonModule, MatSnackBarModule],
  providers: [SnackBarService],
  entryComponents: [SnackBarComponent],
  declarations: [SnackBarComponent]
})
export class NotificationModule {}
