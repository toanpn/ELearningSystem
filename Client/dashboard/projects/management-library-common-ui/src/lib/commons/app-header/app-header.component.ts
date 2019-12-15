import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './app-header.component.html',
  styleUrls: ['./app-header.component.scss']
})
export class AppHeaderComponent implements OnInit {
  @Input() userName = '';
  @Output() logOut: EventEmitter<any> = new EventEmitter();
  constructor() {}

  ngOnInit() {}

  onLogOut() {
    this.logOut.emit({ isLogout: true });
  }
}
