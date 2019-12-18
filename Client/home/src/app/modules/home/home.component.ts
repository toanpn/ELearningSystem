import { Component, OnInit } from '@angular/core';
import { ShareService } from 'src/app/shared/services/share.service';
import { Course } from 'src/app/core/models/course.model';
import { CourseService } from 'src/app/core/services/course.service';
import { Observable, BehaviorSubject } from 'rxjs';
import { UserModel } from 'src/app/core/models/user.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  myCourse: Course;
  listCourse: Course[];
  listCourseFree: Course[];
  typeGetAll: number;
  obserable: Observable<number>;
  type: BehaviorSubject<number>;
  currentUser: UserModel;

  constructor(
    // tslint:disable-next-line:variable-name
    private _shareService: ShareService,
    // tslint:disable-next-line:variable-name
    private _courseService: CourseService
  ) {}
  ngOnInit() {
    this._shareService.broadcastTitle(`HỆ THỐNG HỌC - THI TRỰC TUYẾN TỐT NHẤT`);
    this._shareService.currentUserStream$.subscribe((user: UserModel) => {
      if (this.currentUser === undefined) {
        this.currentUser = user;
      }
      if (user === undefined) {
        this.currentUser = undefined;
      }
    });
    this.loadAllCourse();
    this.loadCourseFree();
  }

  clickCourseType(value: number) {
    this.typeGetAll = value;
    this.type.next(value);
  }

  loadAllCourse() {
    this._courseService
      .loadCoursesPageResults({
        pageNumber: 0,
        pageSize: 6
      })
      .subscribe(res => {
        this.listCourse = res.Data.Results;
      });
  }

  loadCourseFree() {
    this._courseService.loadAllCourseFree().subscribe(res => {
      this.listCourseFree = res.Data;
    });
  }

  loadCourseNew() {
    this._courseService
      .loadAllCourseNew({
        pageNumber: 1,
        pageSize: 6
      })
      .subscribe(res => {
        this.listCourse = res.Results;
      });
  }

  loadCourseHot() {
    this._courseService
      .loadAllCourseHot({
        pageNumber: 1,
        pageSize: 6
      })
      .subscribe(res => {
        this.listCourse = res.Results;
      });
  }
}
