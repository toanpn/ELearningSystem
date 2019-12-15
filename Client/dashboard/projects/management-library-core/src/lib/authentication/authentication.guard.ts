import { Injectable } from '@angular/core';
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  Router
} from '@angular/router';
import { AuthenticationBusinessService } from './authentication-business.service';
import { of } from 'rxjs';

@Injectable()
export class AuthenticationGuard implements CanActivate {
  constructor(
    private router: Router,
    private authenticationService: AuthenticationBusinessService
  ) {}
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    if (this.authenticationService.isAuthenticated) {
      return of(true);
    }

    this.router.navigate(['/auth'], {
      queryParams: { redirect: state.url },
      replaceUrl: true
    });
    return of(true);
  }
}
