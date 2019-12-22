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
import { displayedColumns } from './category.table'
import { ActivatedRoute, Router } from '@angular/router';
import { DashboardSandboxService } from '../../dashboard.sandbox';
import { MatDialog, MatTableDataSource } from '@angular/material';
import { CourseFormDialogComponent } from '../../components/course-form-dialog/course-form-dialog.component';
import { CategoryFormDialogComponent } from '../../components/category-form-dialog/category-form-dialog.component';

@Component({
  selector: 'app-manager-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent extends BaseComponent
  implements OnInit, OnDestroy {
  displayedColumns = displayedColumns;

  category$: Observable<any>;

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
    this.loadCategories(this.filterCourse)
    this.updatePageTitle();
  }

  ngOnDestroy() {
    this.destroyed$.next();
    this.destroyed$.complete();
  }

  onChangePaging(page) {
    this.filterCourse.pageNumber = page;
    this.loadCategories(this.filterCourse);
  }

  onAddNewCategory() {
    const dialogRef = this.dialog.open(CategoryFormDialogComponent, {
      width: '800px',
      data: {
        ActionType: AppConfig.ActionType.INSERT,
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        const createCourse$ = this.createNewCategory(result);
        createCourse$.subscribe(() => {
          this.notificationService.showSuccess(`${AppConfig.MESSAGE.ACCEPT}`);
          this.loadCategories(this.filterCourse);
        });
      }
    });
  }

  onUpdateCategory(category) {
    const dialogRef = this.dialog.open(CategoryFormDialogComponent, {
      width: '800px',
      data: {
        actionType: AppConfig.ActionType.UPDATE,
        category
      }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        const updateCourse$ = this.updateCouse(result, category.Id);
        updateCourse$.subscribe(() => {
          this.notificationService.showSuccess(`${AppConfig.MESSAGE.ACCEPT}`);

          this.loadCategories(this.filterCourse);
        });
      }
    });
  }

  private createNewCategory(data: any) {
    return this.categoryService.createNewCategory(data).pipe(
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

  private updateCouse(data: any, categoryId: number) {
    return this.categoryService.updateCategory(data).pipe(
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

  private loadCategories(filter: { pageSize: string; pageNumber: string }) {
    this.category$ = this.categoryService
      .loadCategories(filter)
      .pipe(takeUntil(this.destroyed$), catchError(this.catchError));

    this.category$.subscribe(res => {
      this.dataSource = new MatTableDataSource<any>(res);
      this.totalItems = /*res.Data.TotalNumberOfRecords*/ 1;
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
