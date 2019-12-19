import { Observable, Subject } from 'rxjs';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { CourseService } from 'src/app/core/services/course.service';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-my-course',
  templateUrl: './my-course.component.html',
  styleUrls: ['./my-course.component.scss']
})
export class MyCourseComponent implements OnInit, OnDestroy {
  ownCourses$: Observable<any>;

  private destroyed$ = new Subject();
  constructor(private courseService: CourseService) {}

  ngOnInit() {
    this.loadOwnCourses();
  }

  ngOnDestroy(): void {
    this.destroyed$.next();
    this.destroyed$.complete();
  }

  loadOwnCourses() {
    this.ownCourses$ = this.courseService
      .loadOwnCourses()
      .pipe(takeUntil(this.destroyed$));
  }
}
