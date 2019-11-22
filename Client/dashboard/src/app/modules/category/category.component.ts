import { Component, OnInit } from '@angular/core';
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
export class CategoryComponent implements OnInit {
  private destroyed$ = new Subject();

  category$: Observable<any>;

  constructor(
    private _router: Router,
    private _notificationService: NotificationService,
    private _categoryService: CategoryService
  ) {
  }

  ngOnInit() {
    this.loadListCategory();
  }

  ngOnDestroy() {
    this.destroyed$.next();
    this.destroyed$.complete();
  }

  loadListCategory() {
    this.category$ = this._categoryService
      .loadListCategories()
      .pipe(takeUntil(this.destroyed$), catchError(this.catchError));
  }

  editCategory(category) {
    this._router.navigateByUrl(`/category-business?id=${category.id}`);
  }

  deleteCategory(category) {
    this._categoryService
      .deleteCategory({ id: category.id })
      .subscribe(() => {
        this.loadListCategory();
        this._notificationService.showSuccess(
          "Xóa thể loại thành công",
          "Thành Công",
          3000
        );
      });
  }

  catchError(err: any) {
    console.log(err);
    return of(null);
  }
}
