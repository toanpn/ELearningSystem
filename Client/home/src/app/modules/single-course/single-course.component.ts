import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CourseService } from './../../shared/services/course.service';

@Component({
  selector: 'app-single-course',
  templateUrl: './single-course.component.html',
  styleUrls: ['./single-course.component.scss']
})
export class SingleCourseComponent implements OnInit {
  course: any;
  teacher: any;
  students: any;

  constructor(
    private route: ActivatedRoute,
    private courseService: CourseService
    ) {
   }

  ngOnInit() {
    // this.route.queryParams.subscribe(params => {
    //   let id = this.route.snapshot.params['id'];
    //     console.log(id);
    //   const userId = params['id'];
    // });
    this.route.queryParams.subscribe(params => {
      if (this.route.snapshot.params['id']) {
        this.getCourse(this.route.snapshot.params['id']);
        this.getUserCourse(this.route.snapshot.params['id']);
        this.getStudents(this.route.snapshot.params['id']);
      }
    });
  }
  getCourse(id: any) {
    const filter = {
      id
    };
    this.courseService.loadCourse(filter).subscribe(res => {
      this.course = res.results;
    });
  }
  
  calculater(lessons: any): string {
    let sec = lessons.reduce(function(prev, cur) {
      return prev + cur.VideoTime;
    }, 0);

    // const minutes: number = Math.floor(sec / 60);
    // return minutes + ':' + (sec - minutes * 60);
    return this.amkmsks(sec);
  }

  amkmsks(num: string) {
    let sec_num = parseInt(num, 10); // don't forget the second param
    let hours   = Math.floor(sec_num / 3600);
    let minutes = Math.floor((sec_num - (hours * 3600)) / 60);
    let seconds = sec_num - (hours * 3600) - (minutes * 60);
    let strHours = hours.toString();
    let strMinutes = minutes.toString();
    let strSeconds = seconds.toString();
    if (hours   < 10) {strHours  = "0" + strHours;}
    if (minutes < 10) {strMinutes = "0" + strMinutes;}
    if (seconds < 10) {strSeconds = "0" + strSeconds;}

    return strHours+':'+strMinutes+':'+strSeconds;
}

  getUserCourse(id: any) {
    const filter = {
      id
    };
    this.courseService.getTeacherByCourseId(filter).subscribe(res => {
      this.teacher = res.results[0].User;
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
