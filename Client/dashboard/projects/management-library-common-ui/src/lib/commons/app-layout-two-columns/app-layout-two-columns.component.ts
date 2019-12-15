import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { Component, OnInit, Input } from '@angular/core';
import { map, shareReplay } from 'rxjs/operators';

@Component({
  selector: 'app-layout-two-columns',
  templateUrl: './app-layout-two-columns.component.html',
  styleUrls: ['./app-layout-two-columns.component.scss']
})
export class AppLayoutTwoColumnsComponent implements OnInit {
  isHandsetLeft$: Observable<boolean> = this.breakpointObserver
    .observe([Breakpoints.XSmall, Breakpoints.Small])
    .pipe(
      map(result => result.matches),
      shareReplay()
    );
  isMobile$: Observable<boolean> = this.breakpointObserver
    .observe([Breakpoints.XSmall, Breakpoints.Small])
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  @Input() pageTitle: string;
  constructor(private breakpointObserver: BreakpointObserver) {}

  ngOnInit() {}
}
