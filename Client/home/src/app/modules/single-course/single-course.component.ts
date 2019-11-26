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
      }
    });
  }
  getCourse(id: any) {
    const filter = {
      id
    };
    this.courseService.loadCourse(filter).subscribe(res => {
      console.log(res)
      this.course = res.results;
    });
    // this.courseService.loadListCourses().subscribe(res => {
    //   console.log(res);
    //   this.course = res.results;
    // });
  }

}
