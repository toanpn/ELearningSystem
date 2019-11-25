import { Component, OnInit } from '@angular/core';
import { ShareService } from 'src/app/shared/services/share.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(
    // tslint:disable-next-line:variable-name
    private _shareService: ShareService
  ) { }

  ngOnInit() {
    this._shareService.broadcastTitle(`BEST ONLINE\n LEARNING SYSTEM`);
  }

}
