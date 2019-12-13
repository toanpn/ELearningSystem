import { Component, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-course-business',
  templateUrl: './course-business.component.html'
})
export class CourseBusinessComponent implements OnInit {
  isLinear = true;
  @ViewChild('stepper', { static: true }) stepper: any;
  CourseId = -1;
  constructor() {}

  ngOnInit() {
  }
  nextTab(){
    this.stepper.selected.completed = true;
    this.stepper.next();
  }
}
