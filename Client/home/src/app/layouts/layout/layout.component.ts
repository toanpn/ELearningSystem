import {Component, OnInit} from '@angular/core';
import {detectBody} from '../../core/helper/app.helpers';
import {ShareService} from '../../shared/services/share.service';


@Component({
  selector: 'app-layout',
  templateUrl: 'layout.component.html',
  host: {
    '(window:resize)': 'onResize()'
  }
})
export class LayoutComponent implements OnInit {

  constructor(
    private shareService: ShareService,
  ) {
  }

  ngOnInit(): void {
    detectBody();
  }

  onResize(): void {
    detectBody();
  }
}
