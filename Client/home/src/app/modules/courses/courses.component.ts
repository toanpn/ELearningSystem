import { Component, OnInit } from '@angular/core';
import { ShareService } from 'src/app/shared/services/share.service';
import { Course } from 'src/app/core/models/course.model';
import { CourseService } from 'src/app/core/services/course.service';
import { ActivatedRoute } from '@angular/router';
import { CategoryService } from 'src/app/core/services/category.service';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.scss']
})
export class CoursesComponent implements OnInit {
  listCourse: Course[];
  countSize: number;
  totalPage: number;
  currentPage$: BehaviorSubject<number>;
  currentPage: number;
  totalItems: number;
  myTitleBreadCrum: string;

  constructor(
    // tslint:disable-next-line:variable-name
    private _shareService: ShareService,
    // tslint:disable-next-line:variable-name
    private _courseService: CourseService,
    // tslint:disable-next-line:variable-name
    private _categoryService: CategoryService,
    // tslint:disable-next-line:variable-name
    private _activatedRoute: ActivatedRoute
  ) {}

  ngOnInit() {
    this._shareService.broadcastTitle('Danh Sách Khóa Học');
    this.countSize = 6;
    this.listCourse = [];
    this.currentPage$ = new BehaviorSubject<number>(1);
    this.currentPage$.asObservable().subscribe(value => {
      this.currentPage = value;
      this.loadData();
    });
  }

  selectPage(page: any) {
    this.currentPage$.next(page);
  }

  loadData() {
    this._activatedRoute.queryParams.subscribe(params => {
      if (params.keyword) {
        this.myTitleBreadCrum = `Kết quả tìm kiếm cho '${params.keyword}'`;
        this.searchCourse(params.keyword);
      } else if (params.idCategory) {
        this.getCourseByCategory(params.idCategory);
      } else if (params.type) {
        if (params.type === '1') {
          this.myTitleBreadCrum = 'Khóa học mới nhất';
          this.getCourseNew();
        } else if (params.type === '2') {
          this.myTitleBreadCrum = 'Khóa học hot nhất';
          this.getCourseNew();
        } else if (params.type === '3') {
          this.myTitleBreadCrum = 'Khóa học miễn phí';
          this.getCourseNew();
        }
      } else {
        this.myTitleBreadCrum = 'Danh sách khóa học';
        this.getListCoursePageResult();
      }
    });
  }

  getListCourse() {
    this._courseService.loadAllCourse().subscribe(res => {
      this.listCourse = res.results;
    });
  }

  getListCoursePageResult() {
    this._courseService
      .loadCoursesPageResults({
        pageNumber: this.currentPage,
        pageSize: this.countSize
      })
      .subscribe(res => {
        this.totalItems = res.Data.TotalNumberOfRecords;
        this.listCourse = res.Data.Results;
        this.totalPage = res.Data.TotalNumberOfPages;
      });
  }

  searchCourse(kw: string) {
    this._courseService
      .searchCourse({
        keyword: kw,
        pageNumber: this.currentPage,
        pageSize: this.countSize
      })
      .subscribe(res => {
        this.totalItems = res.TotalNumberOfRecords;
        this.listCourse = res.Results;
        this.totalPage = res.TotalNumberOfPages;
      });
  }

  getCourseByCategory(id: any) {
    this._categoryService.loadCategory({ Id: id }).subscribe((r: any) => {
      this.myTitleBreadCrum = `Khóa học thể loại '${r.Name}'`;
      this._courseService
        .loadCourseByCategory({
          id: r.Id,
          pageNumber: this.currentPage,
          pageSize: this.countSize
        })
        .subscribe(res => {
          this.totalItems = res.Data.TotalNumberOfRecords;
          this.listCourse = res.Data.Results;
          this.totalPage = res.Data.TotalNumberOfPages;
        });
    });
  }

  getCourseNew() {
    this._courseService
      .loadAllCourseNew({
        pageNumber: this.currentPage,
        pageSize: this.countSize
      })
      .subscribe(res => {
        this.totalItems = res.TotalNumberOfRecords;
        this.listCourse = res.Results;
        this.totalPage = res.TotalNumberOfPages;
      });
  }

  getCourseFree() {
    this._courseService.loadAllCourseFree().subscribe(res => {
      this.totalItems = res.TotalNumberOfRecords;
      this.listCourse = res.Results;
      this.totalPage = res.TotalNumberOfPages;
    });
  }

  loadPage(page: number) {
    this.currentPage$.next(page);
  }
}
