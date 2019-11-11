import {Component, OnDestroy, OnInit} from '@angular/core';
import {smoothlyMenu} from '../../core/helper/app.helpers';
import {AuthService} from '../../core/services/auth/auth.service';
import {Router} from '@angular/router';
import 'rxjs/add/operator/distinctUntilChanged';

declare var jQuery: any;

@Component({
  selector: 'app-topnavbar',
  styleUrls: ['topnavbar.component.scss'],
  templateUrl: 'topnavbar.component.html'
})
export class TopnavbarComponent implements OnInit, OnDestroy {
  constructor(
    private router: Router,
    private authService: AuthService,
  ) {
  }

  ngOnInit(): void {
  }

  logout() {
    this.authService.logout();
    return this.router.navigate(['/login']);
  }

  

  toggleNavigation(): void {
    jQuery('body').toggleClass('mini-navbar');
    smoothlyMenu();
  }

  ngOnDestroy(): void {
  }
}
