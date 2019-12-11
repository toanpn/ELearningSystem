import { NotificationService } from './../../shared/services/notification.service';
import { Router } from '@angular/router';
import { Component, OnInit, OnDestroy, Output, EventEmitter } from '@angular/core';
import { Subject, Observable, of } from 'rxjs';
import { CourseService } from './../../core/services/course.service';
import { takeUntil, catchError } from 'rxjs/operators';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html'
})
export class CoursesComponent implements OnInit, OnDestroy {
  private destroyed$ = new Subject();
  courses$: Observable<any>;

  constructor(
    private courseService: CourseService,
    private router: Router,
    private notificationService: NotificationService
  ) { }

  ngOnInit() {
    this.loadListCourses();
  }

  ngOnDestroy() {
    this.destroyed$.next();
    this.destroyed$.complete();
  }

  loadListCourses() {
    this.courseService.loadListCourses().pipe(takeUntil(this.destroyed$), catchError(this.catchError)).subscribe(res => {
      this.courses$ = res.results;
    });
    //   this.courses$ = this.courseService
    //     .loadListCourses()
    //     .pipe(takeUntil(this.destroyed$), catchError(this.catchError));
  }

  catchError(err: any) {
    console.log(err);
    return of(err);
  }

  editCourse(course) {
    this.router.navigateByUrl(`/course-business?id=${course.Id}`);
  }

  delete(course) {
    this.courseService.deleteCourse(course.Id).pipe(takeUntil(this.destroyed$), catchError(this.catchError)).subscribe(res => {
      if (!res) {
        this.notificationService.showSuccess(
          'Xóa khóa học thành công',
          'Thành công',
          2000
        );
        this.loadListCourses();
      } else {
        this.notificationService.showError(
          'Đã xảy ra lỗi. Vui lòng thử lại sau',
          'Thất bại',
          4000
        );
      }
    });
  }
}
