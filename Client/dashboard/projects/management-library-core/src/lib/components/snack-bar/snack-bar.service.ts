import { Injectable } from '@angular/core';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material';
import { SnackBarComponent } from './snack-bar.component';

export interface MatSnackData {
  content: string;
  type: string;
}

export interface MatSnackType {
  information: string;
  success: string;
  warning: string;
  error: string;
}

@Injectable()
export class SnackBarService {
  readonly type: MatSnackType = {
    information: 'information',
    success: 'success',
    warning: 'warning',
    error: 'error'
  };

  constructor(private snackBar: MatSnackBar) {}

  showInfo(message?: string) {
    return this.open(message, this.type.information);
  }

  showSuccess(message?: string) {
    return this.open(message, this.type.success);
  }

  showError(message?: string) {
    return this.open(message, this.type.error);
  }

  showWarning(message?: string) {
    return this.open(message, this.type.warning);
  }

  private open(message: string, messageType = '') {
    const matSnackData: MatSnackData = {
      content: message,
      type: messageType
    };

    const configSuccess: MatSnackBarConfig = {
      duration: 5000,
      horizontalPosition: 'right',
      verticalPosition: 'top',
      panelClass: ['snack-bar-message', this.type.information]
    };

    if (messageType) {
      configSuccess.panelClass = ['snack-bar-message', messageType];
    }

    return this.snackBar
      .openFromComponent(SnackBarComponent, {
        data: matSnackData,
        ...configSuccess
      })
      .afterDismissed();
  }
}
