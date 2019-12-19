import { Component, OnInit, Input } from '@angular/core';
import { Category } from 'src/app/core/models/category.model';
import { Course } from 'src/app/core/models/course.model';
import { CategoryService } from 'src/app/core/services/category.service';
import { CourseService } from 'src/app/core/services/course.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-rightmenu',
  templateUrl: './rightmenu.component.html'
})
export class RightmenuComponent implements OnInit {
  listCategory: Category[];
  myCategory: Category;
  listCourseNew: Course[];
  listCourseHot: Course[];
  myKeyword = '';

  constructor(
    // tslint:disable-next-line:variable-name
    private _categoryService: CategoryService,
    // tslint:disable-next-line:variable-name
    private _courseService: CourseService,
    // tslint:disable-next-line:variable-name
    private _router: Router
  ) {}

  ngOnInit() {
    this._categoryService.loadAllCategory().subscribe(res => {
      this.listCategory = res;
    });

    this._courseService
      .loadAllCourseNew({
        pageNumber: 1,
        pageSize: 2
      })
      .subscribe(res => {
        this.listCourseNew = res.Results;
      });

    // this._courseService.loadAllCourseHot({
    //   pageNumber: 1,
    //   pageSize: 2
    // })
    // .subscribe(res => {
    //   this.listCourseHot = res.Results;
    // });
  }

  searchCourse() {
    if (this.myKeyword.trim().length > 0) {
      this._router.navigateByUrl(`/courses?keyword=${this.myKeyword.trim()}`);
    }
  }

  getCourseByCategory(cate: any) {
    if (cate === undefined) {
      this._router.navigateByUrl(`/courses`);
    } else {
      this._router.navigateByUrl(`/courses?idCategory=${cate.Id}`);
    }
  }

  getCourseByType(type: any) {
    this._router.navigateByUrl(`/courses?type=${type}`);
  }
}
