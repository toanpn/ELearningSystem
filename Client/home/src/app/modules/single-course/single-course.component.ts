import { CourseService } from 'src/app/core/services/course.service';
import { ChapterService } from './../../core/services/chapter.service';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';
import { ShareService } from 'src/app/shared/services/share.service';
import { CartService } from 'src/app/core/services/cart.service';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { Course } from 'src/app/core/models/course.model';

@Component({
  selector: 'app-single-course',
  templateUrl: './single-course.component.html',
  styleUrls: ['./single-course.component.scss']
})
export class SingleCourseComponent implements OnInit {
  course: any;
  courseId: number;
  teacher: any;
  listChapter: any[];
  listCourses: Course[];
  constructor(
    // tslint:disable-next-line:variable-name
    public _shareService: ShareService,
    private route: ActivatedRoute,
    private courseService: CourseService,
    private cartService: CartService,
    private chapterService: ChapterService,
    private notificationService: NotificationService,
    private router: Router
  ) {
    this.listChapter = new Array();

    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        this.route.queryParams.subscribe(params => {
          if (this.courseId !== this.route.snapshot.params.id) {
            this.courseId = +this.route.snapshot.params.id;
            this.getCourse(this.courseId);
            this.getChapterByCourseId(this.courseId);
            this.getTeacherByCourseId(this.courseId);
          }
        });
      }
    });
  }

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      if (this.route.snapshot.params.id) {
      }
    });
    this.loadRelatedCourses();
  }

  loadRelatedCourses() {
    this.courseService
      .loadCoursesPageResults({
        pageNumber: 0,
        pageSize: 6
      })
      .subscribe(res => {
        this.listCourses = res.Data.Results;
      });
  }
  getTeacherByCourseId(id: any) {
    this.courseService.loadTeacherByCourseId(id).subscribe((res: any) => {
      this.teacher = res.Data;
    });
  }

  getChapterByCourseId(id: any) {
    this.chapterService.loadChaptersByCourseId(id).subscribe((res: any) => {
      this.listChapter = res.Data;
    });
  }

  getCourse(id: any) {
    this.courseService.loadCourse(id).subscribe(res => {
      this.course = res.Data;
      this._shareService.broadcastTitle(this.course.Name);
    });
  }

  addToCart() {
    this.cartService.addCart({ CourseId: this.course.Id }).subscribe(
      () => {
        this.notificationService.showSuccess(
          'Khóa học đã thêm vào rỏ hàng thành công',
          'Thành Công',
          2000
        );
        this.cartService.getNumberCart().subscribe(i => {
          this._shareService.broadcastCartChange(i.Results);
        });
      },
      () => {
        this.notificationService.showError(
          'Khóa học đã có trong rỏ hàng',
          'Lỗi',
          2000
        );
      }
    );
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
