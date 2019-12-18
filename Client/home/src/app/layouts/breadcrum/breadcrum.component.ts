import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-breadcrum',
  templateUrl: './breadcrum.component.html'
})
export class BreadcrumComponent implements OnInit {

  @Input() titlebreadcrum: string;

  constructor() { }

  ngOnInit() {
  }
}
