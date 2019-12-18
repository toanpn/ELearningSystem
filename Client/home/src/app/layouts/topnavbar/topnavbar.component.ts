import {Component, OnDestroy, OnInit} from '@angular/core';
import {smoothlyMenu} from '../../core/helper/app.helpers';
import {AuthService} from '../../core/services/auth/auth.service';
import {Router, ActivatedRoute} from '@angular/router';
import { UserModel } from 'src/app/core/models/user.model';
import { ShareService } from 'src/app/shared/services/share.service';
import { UserService } from 'src/app/core/services/user.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { NotificationConstant } from 'src/app/core/constants/notification.constant';
import { CartService } from 'src/app/core/services/cart.service';


@Component({
  selector: 'app-topnavbar',
  styleUrls: ['topnavbar.component.scss'],
  templateUrl: 'topnavbar.component.html'
})
export class TopnavbarComponent implements OnInit, OnDestroy {
  currentUser: UserModel;
  myTitle: string;
  numberOfItemCart: number;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private authService: AuthService,
    // tslint:disable-next-line:variable-name
    private _shareService: ShareService,
    // tslint:disable-next-line:variable-name
    private _userService: UserService,
    // tslint:disable-next-line:variable-name
    private _notificationService: NotificationService,
    // tslint:disable-next-line:variable-name
    private _cartService: CartService
  ) {
    this.numberOfItemCart = 0;
  }

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

    this._cartService.getNumberCart().subscribe(res => {
      this._shareService.broadcastCartChange(res.Results);
    });

    this._shareService.numberItemOffCartStream$.subscribe( nb => {
      this.numberOfItemCart = nb;
    });

    this._shareService.myTitleStream$.subscribe( (t: string) => {
      this.myTitle = t;
    });

    console.log(this.route.url);
  }

  checkToken() {
      this._userService.getCurrentUser()
          .subscribe((res: ResponseModel<UserModel>) => {
              if (res.StatusCode === 200) {
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
      // tslint:disable-next-line:quotemark
      "Thành công",
      3000
    );
    return this.router.navigate(['/']);
  }
}
