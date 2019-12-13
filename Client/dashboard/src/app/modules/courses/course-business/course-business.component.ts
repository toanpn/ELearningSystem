import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-course-business',
  templateUrl: './course-business.component.html',
  styles: [
    `
    .finish-wrap{
        display: flex;
      justify-content: center;
      align-items: center;
      flex-direction: column;
    }
    .icon-check{
      font-size:120px
    }
    .text-finish{
      font-size:80px
    }
    `
  ]
})
export class CourseBusinessComponent implements OnInit {
  isLinear = true;
  @ViewChild('stepper', { static: true }) stepper: any;
  CourseId = -1;
  constructor(private router: Router) { }

  ngOnInit() {
  }
  nextTab(event$) {
    this.CourseId = event$;
    this.stepper.selected.completed = true;
    this.stepper.next();
  }
  cancel() {
    this.router.navigateByUrl('/courses');
  }
}
