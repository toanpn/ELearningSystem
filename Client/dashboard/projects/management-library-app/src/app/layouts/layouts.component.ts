import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { AuthenticationBusinessService } from '@management-library/core';

@Component({
  selector: 'app-layouts',
  templateUrl: './layouts.component.html',
  styleUrls: ['./layouts.component.scss']
})
export class LayoutsComponent implements OnInit {
  userName: string;
  constructor(
    private authenticationService: AuthenticationBusinessService,
    private router: Router
  ) {
    this.userName = this.authenticationService.credentials.userName;
  }

  ngOnInit() {}

  onLogOut($event: any) {
    if ($event && $event.isLogout) {
      this.authenticationService.logout();
      this.router.navigateByUrl('/auth');
    }
  }
}
