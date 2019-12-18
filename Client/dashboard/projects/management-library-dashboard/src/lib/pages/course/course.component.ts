import { Component, Injector, OnInit, OnDestroy } from '@angular/core';
import { CourseService, CategoryService } from '@management-library/api';
import {
  BaseComponent,
  AppConfig,
  PageModel,
  SnackBarService
} from '@management-library/core';
import { Observable, of, Subject } from 'rxjs';
import { catchError, takeUntil } from 'rxjs/operators';
import { displayedColumns } from './course.table';
import { MatTableDataSource, MatDialog } from '@angular/material';
import { ActivatedRoute, Router } from '@angular/router';
import { DashboardSandboxService } from '../../dashboard.sandbox';
import { CourseFormDialogComponent } from '../../components/course-form-dialog/course-form-dialog.component';

@Component({
  selector: 'app-manager-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.scss']
})
export class CourseComponent extends BaseComponent
  implements OnInit, OnDestroy {
  displayedColumns = displayedColumns;

  course$: Observable<any>;

  categoriesCourse$: Observable<any>;
  categoriesCourse: any[];

  totalItems: any;

  baseUrl: string;

  filterCourse?: {
    pageSize: string;
    pageNumber: string;
  } = {
    pageSize: null,
    pageNumber: null
  };

  dataSource: any;

  private destroyed$ = new Subject();
  constructor(
    injector: Injector,
    private activatedRoute: ActivatedRoute,
    private courseService: CourseService,
    private categoryService: CategoryService,
    private dashBoardSandboxService: DashboardSandboxService,
    private notificationService: SnackBarService,
    private router: Router,
    public dialog: MatDialog
  ) {
    super(injector);

    this.filterCourse.pageNumber = this.pageNumber;
    this.filterCourse.pageSize = this.pageSize;

    this.baseUrl = AppConfig.BASE_URL.dev;
  }

  ngOnInit() {
    this.loadCourseAdvanced(this.filterCourse);

    this.loadCategories();
    this.updatePageTitle();
  }

  ngOnDestroy() {
    this.destroyed$.next();
    this.destroyed$.complete();
  }

  onChangePaging(page) {
    this.filterCourse.pageNumber = page;
    this.loadCourseAdvanced(this.filterCourse);
  }

  onAddNewCourse() {
    const dialogRef = this.dialog.open(CourseFormDialogComponent, {
      width: '800px',
      data: {
        ActionType: AppConfig.ActionType.INSERT,
        categories: this.categoriesCourse
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        const createCourse$ = this.createNewCouse(result);
        createCourse$.subscribe(() => {
          this.notificationService.showSuccess(`${AppConfig.MESSAGE.ACCEPT}`);
          this.loadCourseAdvanced(this.filterCourse);
        });
      }
    });
  }

  onUpdateCourse(course) {
    const dialogRef = this.dialog.open(CourseFormDialogComponent, {
      width: '800px',
      data: {
        actionType: AppConfig.ActionType.UPDATE,
        categories: this.categoriesCourse,
        course
      }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        const updateCourse$ = this.updateCouse(result, course.Id);
        updateCourse$.subscribe(() => {
          this.notificationService.showSuccess(`${AppConfig.MESSAGE.ACCEPT}`);

          this.loadCourseAdvanced(this.filterCourse);
        });
      }
    });
  }

  private createNewCouse(data: any) {
    return this.courseService.createNewCourse(data).pipe(
      takeUntil(this.destroyed$),
      catchError((err: any) => {
        const { error } = err;
        this.notificationService.showError(
          `${AppConfig.MESSAGE.ERROR_SERVER} <br> ${error.detail}`
        );
        return this.catchError(err);
      })
    );
  }

  private updateCouse(data: any, courseId: number) {
    return this.courseService.updateCourse(data, courseId).pipe(
      takeUntil(this.destroyed$),
      catchError((err: any) => {
        const { error } = err;
        this.notificationService.showError(
          `${AppConfig.MESSAGE.ERROR_SERVER} <br> ${error.detail}`
        );
        return this.catchError(err);
      })
    );
  }

  private loadCourseAdvanced(filter: { pageSize: string; pageNumber: string }) {
    this.course$ = this.courseService
      .loadListCourseAdvanced(filter)
      .pipe(takeUntil(this.destroyed$), catchError(this.catchError));

    this.course$.subscribe(res => {
      this.dataSource = new MatTableDataSource<any>(res.Data.Results);
      this.totalItems = res.Data.TotalNumberOfRecords;
    });
  }

  private loadCategories() {
    this.categoriesCourse$ = this.categoryService
      .loadCategories()
      .pipe(takeUntil(this.destroyed$), catchError(this.catchError));
    this.categoriesCourse$.subscribe(res => {
      this.categoriesCourse = res.Data;
    });
  }

  private updatePageTitle() {
    const page = this.activatedRoute.snapshot.data as PageModel;
    console.log(page);
    this.titlePage = page.title;
    this.dashBoardSandboxService.setTitle(`${this.titlePage}`);
    this.setTitle(`${this.titlePage}`);
  }

  private catchError(err) {
    return of(null);
  }
}
