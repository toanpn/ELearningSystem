import { AfterViewInit, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import 'jquery-slimscroll';
import { ShareService } from '../../shared/services/share.service';

declare var jQuery: any;

@Component({
  selector: 'app-navigation',
  templateUrl: 'navigation.component.html',
  styleUrls: ['navigation.component.scss']
})
export class NavigationComponent implements AfterViewInit, OnInit {
  userName: string;

  constructor(private router: Router) {}

  ngOnInit(): void {
    this.userName = localStorage.getItem('user_name');
  }

  ngAfterViewInit() {
    jQuery('#side-menu').metisMenu({ toggle: false });

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
