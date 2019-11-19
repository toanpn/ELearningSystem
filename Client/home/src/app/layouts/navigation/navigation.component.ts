import { AfterViewInit, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

declare var jQuery: any;

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent implements OnInit {
  userName: string;

  constructor(private router: Router) {}

  ngOnInit(): void {
    this.userName = localStorage.getItem('user_name');
  }

  activeRoute(routeName: string): boolean {
    return this.router.url.toString() === routeName;
  }
}
