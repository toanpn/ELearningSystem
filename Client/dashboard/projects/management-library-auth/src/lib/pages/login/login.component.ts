import { Credentials } from '@management-library/core';
import { Title } from '@angular/platform-browser';
import { AuthenticationService } from '@management-library/api';
import {
  Component,
  OnInit,
  OnDestroy,
  Injector,
  AfterViewInit
} from '@angular/core';
import { Subscription, Observable, of } from 'rxjs';
import { Router } from '@angular/router';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { map, shareReplay, tap, switchMap, catchError } from 'rxjs/operators';
import {
  BaseComponent,
  AuthenticationBusinessService,
  SnackBarService
} from '@management-library/core';

declare var particlesJS: any;

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent extends BaseComponent
  implements OnInit, OnDestroy, AfterViewInit {
  private subcription: Subscription = new Subscription();

  isMobile$: Observable<boolean> = this.breakpointObserver
    .observe([Breakpoints.XSmall, Breakpoints.Small])
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(
    public injector: Injector,
    private titleServive: Title,
    private authenApiService: AuthenticationService,
    private authBusinessService: AuthenticationBusinessService,
    private snackBarService: SnackBarService,
    private router: Router,
    private breakpointObserver: BreakpointObserver
  ) {
    super(injector);
    this.titleServive.setTitle('Đăng nhập ứng dụng');
  }

  ngOnInit() {
    if (this.authBusinessService.isAuthenticated) {
      this.router.navigateByUrl('/');
    }
    particlesJS.load(
      'app-left-content',
      'assets/particles/particles.json',
      null
    );
  }

  ngOnDestroy(): void {
    if (this.subcription) {
      this.subcription.unsubscribe();
    }
    this.removeClassPage('LoginComponent');
  }

  ngAfterViewInit() {
    this.addClassPage('LoginComponent');
  }

  submitLogin(event: any) {
    console.log(event);
    const auth$ = this.authenApiService
      .login({ username: event.data.username, password: event.data.password })
      .pipe(
        tap(response => console.log(response)),
        switchMap(response => {
          const data: Credentials = {
            userName: response.userName,
            token: response.access_token
          };

          return of(data);
        }),
        catchError(err => {
          this.snackBarService.showError('Đăng nhập thất bại');
          return of(null);
        })
      );
    this.subcription.add(
      auth$.subscribe((data: any) => {
        if (data) {
          this.authBusinessService.login(data, event.data.remember);
          this.snackBarService.showSuccess('Đăng nhập thành công');
          this.router.navigateByUrl('/');
        }
      })
    );
  }
}
