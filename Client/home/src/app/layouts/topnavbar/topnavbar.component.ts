import {Component, OnDestroy, OnInit} from '@angular/core';
import {smoothlyMenu} from '../../core/helper/app.helpers';
import {AuthService} from '../../core/services/auth/auth.service';
import {Router} from '@angular/router';
import { UserModel } from 'src/app/core/models/user.model';
import { ShareService } from 'src/app/shared/services/share.service';
import { UserService } from 'src/app/core/services/user.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { NotificationConstant } from 'src/app/core/constants/notification.constant';


@Component({
  selector: 'app-topnavbar',
  styleUrls: ['topnavbar.component.scss'],
  templateUrl: 'topnavbar.component.html'
})
export class TopnavbarComponent implements OnInit, OnDestroy {
  currentUser: UserModel;
  myTitle: string;

  constructor(
    private router: Router,
    private authService: AuthService,
    private _shareService: ShareService,
    private _userService: UserService,
    private _notificationService: NotificationService
  ) {}

  ngOnInit(): void {
    if (localStorage.getItem('access_token')) {
      this.checkToken();
    }

    this._shareService.currentUserStream$.subscribe((user: UserModel) => {
      if (this.currentUser === undefined) {
        this.currentUser = user;
      }
      if (user === undefined) {
        this.currentUser = undefined;
      }
    });

    this._shareService.myTitleStream$.subscribe( (t: string) =>{
      this.myTitle = t;
    })
  }

  checkToken() {
      this._userService

      this._userService.getCurrentUser()
          .subscribe((res: ResponseModel<UserModel>)=>{
              if(res.StatusCode ==200){
                this._shareService.broadcastCurrentUserChange(res.Data);
                localStorage.setItem('current_user', JSON.stringify(res.Data));
              }
          });
  }

  ngOnDestroy(): void {
  }

  logout() {
    this.authService.logout();
    localStorage.removeItem('current_user');
    this._shareService.broadcastCurrentUserChange(undefined);
    this._notificationService.showSuccess(
      NotificationConstant.LOGOUT_SUCCESS,
      "Thành công",
      3000
    );
    return this.router.navigate(['/']);
  }
}
