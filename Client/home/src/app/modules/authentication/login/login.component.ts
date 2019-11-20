import { NotificationService } from './../../../shared/services/notification.service';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { AuthService } from 'src/app/core/services/auth/auth.service';
import { NotificationConstant } from 'src/app/core/constants/notification.constant';

// declare var particlesJS: any;

@Component({
  selector: 'app-login',
  templateUrl: 'login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {
  private subcription: Subscription = new Subscription();

  isMobile$: Observable<boolean> = this.breakpointObserver
    .observe([Breakpoints.XSmall, Breakpoints.Small])
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  colsLeft = 8;
  colsRight = 4;
  cols = 12;
  rowHeight = '768px';

  constructor(
    private router: Router,
    private breakpointObserver: BreakpointObserver,
    private authService: AuthService,
    private notificationService: NotificationService
  ) {
    this.isMobile$.subscribe(isMobile => this.setCols(isMobile));
  }

  ngOnInit() {
    // particlesJS.load(
    //   'app-left-content',
    //   'assets/particles/particles.json',
    //   null
    // );
  }

  ngOnDestroy(): void {
    if (this.subcription) {
      this.subcription.unsubscribe();
    }
  }

  private setCols(isMobile: boolean) {
    if (isMobile) {
      this.cols = this.colsLeft = this.colsRight = 1;
      this.rowHeight = '100vh';
    } else {
      this.colsLeft = 8;
      this.colsRight = 4;
      this.cols = 12;
      this.rowHeight = '768px';
    }
  }

  submitLogin(event) {
    const email = event.formData.username;
    const password = event.formData.password;
    this.authService.login(email, password).subscribe(
      (res: any) => {
        if (res) {
          this.router.navigate(['/dashboard']);
          this.notificationService.showSuccess(
            NotificationConstant.LOGIN_SUCCESS,
            res.message,
            3000
          );
        } else {
          this.notificationService.showError(
            NotificationConstant.LOGIN_ERROR,
            res.message,
            3000
          );
        }
      },
      error => {
        alert('Da co loi xay ra!');
        console.log(error);
      }
    );
  }
}
