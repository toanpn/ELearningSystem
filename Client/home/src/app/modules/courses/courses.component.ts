import { Component, OnInit } from '@angular/core';
import { ShareService } from 'src/app/shared/services/share.service';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.scss']
})
export class CoursesComponent implements OnInit {

  constructor(
    private _shareService:ShareService
  ) { }

  ngOnInit() {
    this._shareService.broadcastTitle('Course List');
  }
}
