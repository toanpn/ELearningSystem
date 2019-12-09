import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject, Observable, of } from 'rxjs';
import { Router } from '@angular/router';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { CategoryService } from 'src/app/core/services/category.service';
import { takeUntil, catchError } from 'rxjs/operators';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent implements OnInit, OnDestroy {
  private destroyed$ = new Subject();

  category$: Observable<any>;

  constructor(
    private router: Router,
    private notificationService: NotificationService,
    private categoryService: CategoryService
  ) { }

  ngOnInit() {
    this.loadListCategory();
  }

  ngOnDestroy() {
    this.destroyed$.next();
    this.destroyed$.complete();
  }

  loadListCategory() {
    this.category$ = this.categoryService
      .loadListCategories()
      .pipe(takeUntil(this.destroyed$), catchError(this.catchError));
  }

  editCategory(category) {
    this.router.navigateByUrl(`/category-business?id=${category.Id}`);
  }

  deleteCategory(category) {
    this.categoryService.deleteCategory({ id: category.Id }).subscribe(() => {
      this.loadListCategory();
      this.notificationService.showSuccess(
        'Xóa thể loại thành công',
        'Thành Công',
        3000
      );
    });
  }

  catchError(err: any) {
    console.log(err);
    return of(null);
  }
}
