import { CodeConstant } from './../../../core/constants/code.constant';
import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {NotificationService} from '../../../shared/services/notification.service';
import { AuthService } from 'src/app/core/services/auth/auth.service';
import { NotificationConstant } from 'src/app/core/constants/notification.constant';
import { ResponseModel } from 'src/app/core/models/response.model';
import { TokenModel } from 'src/app/core/models/token.model';

@Component({
  selector: 'app-login',
  templateUrl: 'login.component.html'
})
export class LoginComponent implements OnInit {
  /* Login FormGroup */
  loginForm: FormGroup;
  /* If login successfully, redirect to returnUrl */
  returnUrl: string;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService,
    private notificationService: NotificationService,
  ) {
  }

  /**
   * @description: Get controls from formGroup: changePasswordForm
   * @returns: FormControls
   */
  get f() {
    return this.loginForm.controls;
  }

  /**
   * @description: lifecycle hook OnInit
   */
  ngOnInit(): void {
    // Initial formGroup: loginForm
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required]],
      password: ['', [Validators.required]]
    });
    this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/';
  }

  login() {
    const email = this.f.email.value.toString().trim().toLowerCase();
    const password = this.f.password.value.toString().trim();
    this.authService.login(email, password)
      .subscribe((res: ResponseModel<TokenModel>) => {
          if (res.code === CodeConstant.SUCCESS) {
            this.router.navigate(['/dashboard']);
            this.notificationService.showSuccess(NotificationConstant.LOGIN_SUCCESS, res.message, 3000);
          } else if (res.code === CodeConstant.FORBIDDEN) {
            this.notificationService.showError(NotificationConstant.LOGIN_ERROR, res.message, 3000);
          } else {
            this.notificationService.showError(NotificationConstant.LOGIN_ERROR, res.message, 3000);
          }
        },
        (error) => {
          console.log(error);
        }
      );
  }

  checkValidForm() {
    return !((this.f.email.value !== null && this.f.email.value !== undefined && this.f.email.value.trim() !== '')
      && (this.f.password.value !== null && this.f.password.value !== undefined && this.f.password.value.trim() !== ''));
  }

  validSpacePassword(event: any) {
    if (event.target.value.trim() === '') {
      event.target.value = event.target.value.replace(event.target.value, '');
    }
  }
}
