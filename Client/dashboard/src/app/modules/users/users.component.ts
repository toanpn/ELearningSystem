import { NotificationService } from './../../shared/services/notification.service';
import { Router } from '@angular/router';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject, Observable, of } from 'rxjs';
import { UserService } from './../../core/services/user.service';
import { takeUntil, catchError } from 'rxjs/operators';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit, OnDestroy {
  private destroyed$ = new Subject();

  users$: Observable<any>;

  constructor(
    private userService: UserService,
    private router: Router,
    private notificationService: NotificationService
  ) { }

  ngOnInit() {
    this.loadListUsers();
  }

  ngOnDestroy() {
    this.destroyed$.next();
    this.destroyed$.complete();
  }

  loadListUsers() {
    this.users$ = this.userService
      .loadListUsers()
      .pipe(takeUntil(this.destroyed$), catchError(this.catchError));
  }

  catchError(err: any) {
    console.log(err);
    return of(null);
  }

  editUser(user) {
    this.router.navigateByUrl(`/user-business?id=${user.Id}`);
  }

  setRole(user: any, roleId: number) {
    const data = {
      UserId: user.Id,
      RoleId: roleId
    };
    this.userService.addRole(data).subscribe(
      () => {
        this.notificationService.showSuccess(
          'Thêm quyền người dùng thành công',
          'Thành công',
          3000
        );
        this.router.navigateByUrl('/users');
      },
      () => {
        this.notificationService.showError(
          'Thêm quyền người dùng thất bại',
          'Thất bại',
          3000
        );
        this.router.navigateByUrl('/users');
      }
    );
  }
}
