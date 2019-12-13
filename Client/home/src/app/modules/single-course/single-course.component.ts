import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CourseService } from './../../shared/services/course.service';
import { ShareService } from 'src/app/shared/services/share.service';
import { CartService } from 'src/app/core/services/cart.service';
import { NotificationService } from 'src/app/shared/services/notification.service';

@Component({
  selector: 'app-single-course',
  templateUrl: './single-course.component.html',
  styleUrls: ['./single-course.component.scss']
})
export class SingleCourseComponent implements OnInit {
  course: any;
  teacher: any;
  students: any;
  teacherRatingAVG: number;
  teacherCountReviews: number;
  teacherNumberOfStudent: number;
  teacherNumberOfCourse: number;
  courseNumberOfLesson: string;
  courseTotalTime: string;

  constructor(
    // tslint:disable-next-line:variable-name
    public _shareService: ShareService,
    private route: ActivatedRoute,
    private courseService: CourseService,
    private cartService: CartService,
    private notificationService: NotificationService
    ) {
   }

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      if (this.route.snapshot.params.id) {
        this.getCourse(this.route.snapshot.params.id);
        this.getTeacher(this.route.snapshot.params.id);
        this.getStudents(this.route.snapshot.params.id);
      }
    });
  }

  getCourse(id: any) {
    const filter = {
      id
    };
    this.courseService.loadCourse(filter).subscribe(res => {
      this.course = res.results;
      this._shareService.broadcastTitle(this.course.Name);
    });
  }

  // calculater(lessons: any): string {
  //   // tslint:disable-next-line:only-arrow-functions
  //   const sec = lessons.reduce(function(prev, cur) {
  //     console.log(this.course.Chapters);
  //   // this.courseTotalTime = this.course.Chapters;
  //   // let sec = this.course.Chapters.reduce(function(prev, cur) {
  //   //   return prev + cur.VideoTime;
  //   // }, 0);
  //   this.courseNumberOfLesson = '122';
  //   });
  // }

  FormatingSecond(lessons: any): string {
    // tslint:disable-next-line:only-arrow-functions
    const sec = lessons.reduce( function( prev, cur) {
      return prev + cur.VideoTime;
    }, 0);

    // const minutes: number = Math.floor(sec / 60);
    // return minutes + ':' + (sec - minutes * 60);
    return this.secondtoHHMMSS(sec);
  }

  secondtoHHMMSS(num: string) {
    // tslint:disable-next-line:variable-name
    const sec_num = parseInt(num, 10); // don't forget the second param
    const hours   = Math.floor(sec_num / 3600);
    const minutes = Math.floor((sec_num - (hours * 3600)) / 60);
    const seconds = sec_num - (hours * 3600) - (minutes * 60);
    let strHours = hours.toString();
    let strMinutes = minutes.toString();
    let strSeconds = seconds.toString();
    if (hours   < 10) {strHours  = '0' + strHours; }
    if (minutes < 10) {strMinutes = '0' + strMinutes; }
    if (seconds < 10) {strSeconds = '0' + strSeconds; }

    return strHours + ':' + strMinutes + ':' + strSeconds;
  }

  addToCart() {
    this.cartService.addCart({IdCourse: this.course.Id }).subscribe(r => {
      this.cartService.getNumberCart().subscribe(i => {
        this._shareService.broadcastCartChange(i.Results);
      });
      console.log(r);
      this.notificationService.showSuccess('Khóa học đã thêm vào rỏ hàng thành công',
      'Thành Công',
      2000);
    }, () => {
      this.notificationService.showError('Khóa học đã có trong rỏ hàng',
      'Lỗi',
      2000);
    });
  }

  getTeacher(id: any) {
    const filter = {
      id
    };
    this.courseService.getTeacherByCourseId(filter).subscribe(res => {
      console.log(res.results);
      this.teacher = res.results;
      this.teacherNumberOfCourse = this.teacher.UserCourse.length;
      // this.teacherNumberOfStudent = this.teacher.UserCourse.length - 1;
      this.teacherNumberOfStudent = 12;
      this.teacherRatingAVG = 3.4;
    });
  }

  getStudents(id: any) {
    const filter = {
      id
    };
    this.courseService.getStudentsByCourseId(filter).subscribe(res => {
      // console.log(res.results);
      this.students = res.results;
    });
  }
}
