import { DashboardSandboxService } from './../../dashboard.sandbox';
import { Component, OnInit, Injector } from '@angular/core';
import { BaseComponent, PageModel } from '@management-library/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent extends BaseComponent implements OnInit {
  constructor(
    injector: Injector,
    private activatedRoute: ActivatedRoute,
    private dashBoardSandboxService: DashboardSandboxService
  ) {
    super(injector);
  }

  ngOnInit() {
    this.updatePageTitle();
  }

  private updatePageTitle() {
    const page = this.activatedRoute.snapshot.data as PageModel;
    console.log(page);
    this.titlePage = page.title;
    this.dashBoardSandboxService.setTitle(`${this.titlePage}`);
    this.setTitle(`${this.titlePage}`);
  }
}
