import {NgModule} from '@angular/core';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {ErrorInterceptor} from './interceptors/error.interceptor';
import {JwtInterceptor} from './interceptors/jwt.interceptor';

@NgModule({
  imports: [
    HttpClientModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
  ],
  declarations: [],
  exports: []
})

export class CoreModule {
}
