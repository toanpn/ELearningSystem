import {Injectable} from '@angular/core';
import {HttpEvent, HttpHandler, HttpHeaders, HttpInterceptor, HttpRequest} from '@angular/common/http';
import {AuthService} from '../services/auth/auth.service';
import {Observable} from 'rxjs';
import {ActivatedRoute} from '@angular/router';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  constructor(
    private route: ActivatedRoute
  ) {
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // add authorization header with jwt token if available
    const jwt = AuthService.getAccessToken();
    if (jwt !== null && jwt !== undefined) {
      req = req.clone({
        headers: req.headers.append('Authorization', 'Bearer ' + JSON.parse(jwt))
      });
      return next.handle(req);
    } else {
      req = req.clone({
        headers: req.headers.append('Content-Type', 'application/json' )
      });
      return next.handle(req);
    }
  }
}