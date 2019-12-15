import { Observable } from 'rxjs';
import { Injectable, Inject } from '@angular/core';
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent
} from '@angular/common/http';
@Injectable()
export class ApiPrefixInterceptor implements HttpInterceptor {
  constructor(@Inject('env') private env: any) {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    if (!/^(http|https):/i.test(request.url)) {
      console.log(this.env);
      request = request.clone({
        url: this.env.host + request.url
      });
    }
    return next.handle(request);
  }
}
