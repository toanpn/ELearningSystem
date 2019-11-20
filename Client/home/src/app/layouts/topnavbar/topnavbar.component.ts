import {Component, OnDestroy, OnInit} from '@angular/core';
import {smoothlyMenu} from '../../core/helper/app.helpers';
import {AuthService} from '../../core/services/auth/auth.service';
import {Router} from '@angular/router';
import { UserModel } from 'src/app/core/models/user.model';
import { ShareService } from 'src/app/shared/services/share.service';
import { UserService } from 'src/app/core/services/user.service';
import { ResponseModel } from 'src/app/core/models/response.model';


@Component({
  selector: 'app-topnavbar',
  styleUrls: ['topnavbar.component.scss'],
  templateUrl: 'topnavbar.component.html'
})
export class TopnavbarComponent implements OnInit, OnDestroy {
  currentUser: UserModel;

  constructor(
    private router: Router,
    private authService: AuthService,
    private _shareService: ShareService,
    private _userService: UserService
  ) {}

  ngOnInit(): void {
    if(localStorage.getItem('access_token')) {
      // this.getCurrentUser();
    }else{
      this.currentUser = undefined;
    }

    // this._shareService.currentUserStream$.subscribe((user: UserModel) => {
    //   if (this.currentUser === undefined) {
    //     this.currentUser = user;
    //   }
    //   if (user === undefined) {
    //     this.currentUser = undefined;
    //   }
    // });
  }

  ngOnDestroy(): void {
  }

  logout() {
    this.authService.logout();
    localStorage.removeItem('current_user');
    this._shareService.broadcastCurrentUserChange(undefined);
    console.log('log out');
    return this.router.navigate(['/']);
  }

  // getCurrentUser() {
  //   this._userService.getCurrentUser()
  //     .subscribe((res: ResponseModel<UserModel>) => {
  //       if (res.code === 200) {
  //         this._shareService.broadcastCurrentUserChange(res.data);

  //         localStorage.setItem('current_user', JSON.stringify(res.data));
  //       }
  //     });
  // }
}
