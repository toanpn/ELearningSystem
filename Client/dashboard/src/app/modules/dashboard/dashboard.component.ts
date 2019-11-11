import { Component, OnDestroy, OnInit } from '@angular/core';
@Component({
  selector: 'app-dashboard',
  templateUrl: 'dashboard.component.html',
  styleUrls: ['dashboard.component.scss']
})
export class DashboardComponent implements OnInit, OnDestroy {
  public nav: any;

  public value: Date = new Date ();

  public constructor(
  ) {
    this.nav = document.querySelector('nav.navbar');
  }

  public ngOnInit(): any {
    this.nav.className += ' white-bg';
  }

  public ngOnDestroy(): any {
    this.nav.classList.remove('white-bg');
  }
}
