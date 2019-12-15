import { DashboardSandboxService } from './../../dashboard.sandbox';
import { Observable } from 'rxjs';
import { DashBoardNavigation } from './../../sidebar.navigation';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-managment-library-layout',
  templateUrl: './managment-library-layout.component.html',
  styleUrls: ['./managment-library-layout.component.scss']
})
export class ManagmentLibraryLayoutComponent implements OnInit {
  pageTitle$: Observable<string>;
  menus: any;
  constructor(private dashboardSandboxService: DashboardSandboxService) {
    this.menus = DashBoardNavigation;
  }

  ngOnInit() {
    this.pageTitle$ = this.dashboardSandboxService.getTitle();
  }
}
