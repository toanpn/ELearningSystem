import { BrowserModule } from '@angular/platform-browser';
import {
  NgModule,
  Optional,
  SkipSelf,
  ModuleWithProviders
} from '@angular/core';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ApiPrefixInterceptor } from './interceptors/api-prefix.interceptor';
import { CommonModule } from '@angular/common';
import { AuthenticationBusinessService } from './authentication/authentication-business.service';
import { CredentialsService } from './singleton-services/credentials.service';
import { AuthenticationGuard } from './authentication/authentication.guard';
import { NotificationModule } from './components/snack-bar/snack-bar.module';

@NgModule({
  declarations: [],
  imports: [CommonModule, HttpClientModule, BrowserModule, NotificationModule],
  exports: [],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ApiPrefixInterceptor,
      multi: true
    },
    AuthenticationBusinessService,
    CredentialsService,
    AuthenticationGuard
  ]
})
export class ManagementLibraryCoreModule {
  constructor(
    @Optional() @SkipSelf() parentModule: ManagementLibraryCoreModule
  ) {
    if (parentModule) {
      throw new Error(
        `${parentModule} has already been loaded. Import Core module in the AppModule only.`
      );
    }
  }

  static forRoot(environment: any): ModuleWithProviders {
    return {
      ngModule: ManagementLibraryCoreModule,
      providers: [
        ApiPrefixInterceptor,
        { provide: 'env', useValue: environment }
      ]
    };
  }
}
