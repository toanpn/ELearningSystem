import { Component, OnInit } from '@angular/core';
import { ShareService } from 'src/app/shared/services/share.service';
import { Course } from 'src/app/core/models/course.model';
import { CourseService } from 'src/app/core/services/course.service';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.scss']
})
export class CoursesComponent implements OnInit {

  listCourse: Course[];
  countSize: number;

  constructor(
    // tslint:disable-next-line:variable-name
    private _shareService: ShareService,
    // tslint:disable-next-line:variable-name
    private _courseService: CourseService,
  ) { }

  ngOnInit() {
    this._shareService.broadcastTitle('Course List');
    this.countSize = 6;
    this.getListCourse();
  }

  getListCourse() {
    this._courseService.loadAllCourse()
        .subscribe(res => {
          this.listCourse = res.results;
        });
  }
}
