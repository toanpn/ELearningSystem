import { Component, OnInit, Input } from '@angular/core';
import { Course } from 'src/app/core/models/course.model';

@Component({
  selector: 'app-item-courser',
  templateUrl: './item-courser.component.html',
  styleUrls: ['./item-courser.component.scss']
})
export class ItemCourserComponent implements OnInit {
  @Input() course: any;

  constructor() {}

  ngOnInit() {}
}
