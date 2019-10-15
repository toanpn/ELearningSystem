import {AfterViewInit, Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import 'jquery-slimscroll';
import {ShareService} from '../../shared/services/share.service';
import {MatDialog} from '@angular/material';
import {NotificationService} from '../../shared/services/notification.service';
import { VariablesConstant } from 'src/app/core/constants/variables.constant';

declare var jQuery: any;

@Component({
  selector: 'app-navigation',
  templateUrl: 'navigation.component.html',
  styleUrls: ['navigation.component.scss']
})
export class NavigationComponent implements AfterViewInit, OnInit {
  // currentUser: UserModel;

  constructor(
    private router: Router,
    private shareService: ShareService,
    private dialog: MatDialog,
    private notificationService: NotificationService) {
  }

  ngOnInit(): void {
    this.shareService.currentUserStream$
      .subscribe((user) => {
        // this.currentUser = user;
      });
    this.getCurrentUser();
  }

  private getCurrentUser() {
    // this.userService.getCurrentUser()
    //   .subscribe((user) => {
    //     this.currentUser = user.data;
    //   });
  }

  ngAfterViewInit() {
    jQuery('#side-menu').metisMenu({toggle: false});

    if (jQuery('body').hasClass('fixed-sidebar')) {
      jQuery('.sidebar-collapse').slimscroll({
        height: '100%'
      });
    }
  }

  activeRoute(routeName: string): boolean {
    return this.router.url.toString() === routeName;
  }
}
