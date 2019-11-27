import { Component, OnInit, Input } from '@angular/core';
import { Category } from 'src/app/core/models/category.model';
import { Course } from 'src/app/core/models/course.model';
import { CategoryService } from 'src/app/core/services/category.service';
import { CourseService } from 'src/app/core/services/course.service';

@Component({
  selector: 'app-rightmenu',
  templateUrl: './rightmenu.component.html'
})
export class RightmenuComponent implements OnInit {

  listCategory: Category[];
  myCategory: Category;
  listCourseNew: Course[];

  constructor(
    // tslint:disable-next-line:variable-name
    private _categoryService: CategoryService,
    // tslint:disable-next-line:variable-name
    private _courseService: CourseService,
  ) { }

  ngOnInit() {
    this._categoryService.loadAllCategory()
    .subscribe(res => {
      this.listCategory = res;
    });

    this._courseService.loadAllCourseNew()
    .subscribe(res => {
      this.listCourseNew = res.results;
    });
  }

  getCourseByCategory(category: Category) {
    if (category === undefined) {
      this._categoryService.loadAllCategory()
      .subscribe(res => {
        this.listCategory = res;
      });
    } else {

    }
  }
}
