import { Injectable } from '@angular/core';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';
import { AuthService } from './../services/auth/auth.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(
    private router: Router,
    private authService: AuthService
  ) {
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(catchError(err => {
      if (err instanceof HttpErrorResponse) {
        // do error handling here
        if (err.status === 403 || err.status === 401) {
          this.authService.logout();
          //console.log('expired token');
          this.router.navigate(['/login'], { skipLocationChange: true });

        }
      }
      const error = err.error.message || err.statusText;
      return throwError(error);

    }));
  }
}
