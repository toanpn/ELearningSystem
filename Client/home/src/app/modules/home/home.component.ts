import { Component, OnInit } from '@angular/core';
import { ShareService } from 'src/app/shared/services/share.service';
import { Course } from 'src/app/core/models/course.model';
import { CourseService } from 'src/app/core/services/course.service';
import { Observable, BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  myCourse: Course;
  listCourse: Course[];
  typeGetAll: number;
  obserable: Observable<number>;
  type: BehaviorSubject<number>;

  constructor(
    // tslint:disable-next-line:variable-name
    private _shareService: ShareService,
    // tslint:disable-next-line:variable-name
    private _courseService: CourseService,
  ) { }
// sao phai dugn may cai observe này??? click thêm class :v
  ngOnInit() {
    this._shareService.broadcastTitle(`BEST ONLINE LEARNING SYSTEM`);
    // tslint:disable-next-line:max-line-length
    this.type = new BehaviorSubject<number>(0);
    this.obserable = this.type.asObservable();
    this.obserable.subscribe( t => {
      switch (t) {
        case 0:
          this.loadAllCourse();
          break;
        case 1:
          this.loadCourseNew();
          break;
        case 2:
          this.loadCourseHot();
          break;
      }
    });

    this.clickCourseType(0);
  }

  clickCourseType(value: number) {
    this.typeGetAll = value;
    this.type.next(value);
  }

  loadAllCourse() {
    this._courseService.loadAllCourse().subscribe(res => {
      this.listCourse = res.results;
      console.log(res.results);
    });
  }

  loadCourseNew() {
    this._courseService.loadAllCourse().subscribe(res => {
      this.listCourse = res.results;
      console.log(res.results);
    });
  }

  loadCourseHot() {
    this._courseService.loadAllCourse().subscribe(res => {
      this.listCourse = res.results;
      console.log(res.results);
    });
  }
}
