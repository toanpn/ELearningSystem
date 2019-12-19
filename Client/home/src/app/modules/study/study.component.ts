import { ChapterService } from './../../core/services/chapter.service';
import { CourseService } from 'src/app/core/services/course.service';
import { Subject, Observable } from 'rxjs';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';
import {
  Component,
  OnInit,
  ViewChild,
  OnDestroy,
  ElementRef
} from '@angular/core';
import { TabsetComponent } from 'ngx-bootstrap';
import { takeUntil } from 'rxjs/operators';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-study',
  templateUrl: './study.component.html',
  styleUrls: ['./study.component.scss']
})
export class StudyComponent implements OnInit, OnDestroy {
  courseId: any;
  courseContent: any;
  urlVideo: any;
  titleVideo: any;
  course$: Observable<any>;
  teacher$: Observable<any>;
  private destroyed$ = new Subject();
  @ViewChild('staticTabs', { static: false }) staticTabs: TabsetComponent;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private chapterService: ChapterService,
    private courseService: CourseService,
    private sanitizer: DomSanitizer
  ) {
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        this.route.queryParams.subscribe(params => {
          if (this.courseId !== this.route.snapshot.params.id) {
            this.courseId = +this.route.snapshot.params.id;
            this.loadContentCourseById(this.courseId);
            this.loadCourse(this.courseId);
            this.loadTeacherByCourseId(this.courseId);
          }
        });
      }
    });
  }

  ngOnInit() {}

  ngOnDestroy(): void {
    this.destroyed$.next();
    this.destroyed$.complete();
  }

  loadContentCourseById(courseId: any) {
    const courseContent$ = this.chapterService
      .loadChaptersByCourseId(courseId)
      .pipe(takeUntil(this.destroyed$));
    courseContent$.subscribe((res: any) => {
      this.courseContent = res.Data;
      if (this.courseContent.length > 0) {
        const firstElement = this.courseContent[0].Lessons[0];
        this.urlVideo = this.sanitizer.bypassSecurityTrustResourceUrl(
          firstElement.VideoUrl
        );
        this.titleVideo = firstElement.Name;
      }
    });
  }

  loadCourse(courseId: any) {
    this.course$ = this.courseService
      .loadCourse(courseId)
      .pipe(takeUntil(this.destroyed$));
  }

  loadTeacherByCourseId(courseId: any) {
    this.teacher$ = this.courseService
      .loadTeacherByCourseId(courseId)
      .pipe(takeUntil(this.destroyed$));
  }

  selectTab(tabId: number) {
    this.staticTabs.tabs[tabId].active = true;
  }

  onSelectedChapter(lesson) {
    this.urlVideo = this.sanitizer.bypassSecurityTrustResourceUrl(
      lesson.VideoUrl
    );
    this.titleVideo = lesson.Name;
  }

  convertSecondToTime(second) {
    let hours = Math.floor(second / 3600);
    second %= 3600;
    let minutes = Math.floor(second / 60);
    let seconds = second % 60;

    minutes = +String(minutes).padStart(2, '0');
    hours = +String(hours).padStart(2, '0');
    seconds = +String(seconds).padStart(2, '0');
    return hours + 'h' + ' : ' + minutes + 'm' + ' : ' + seconds + 's';
  }
}
