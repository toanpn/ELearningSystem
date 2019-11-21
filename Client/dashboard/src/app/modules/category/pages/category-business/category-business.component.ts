import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { CategoryService } from 'src/app/core/services/category.service';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-category-business',
  templateUrl: './category-business.component.html',
  styleUrls: ['./category-business.component.scss']
})
export class CategoryBusinessComponent implements OnInit {
  formData: FormGroup;
  isUpdate = false;
  category: any;
  constructor(
    private formBuilder: FormBuilder,
    private categoryService: CategoryService,
    private notificationService: NotificationService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.initForm();
  }

  get form() {
    return this.formData.controls;
  }
  initForm() {
    this.formData = this.formBuilder.group({
      name: ''
    });
  }

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      if (params.id) {
        this.getCategory(params.id);
        this.isUpdate = true;
      }
    });
  }

  getCategory(id: any) {
    const filter = {
      id
    };
    this.categoryService.loadCategory(filter).subscribe(res => {
      this.category = res;
      this.setValueForm(this.category);
      this.isUpdate = true;
    });
  }

  setValueForm(category: any) {
    this.formData.patchValue({
      name: category.name
    });
  }

  onCreate() {
    const cate = {
      name: this.form.name.value.toString().trim()
    };
    this.categoryService.createCategory(cate).subscribe(
      () => {
        this.notificationService.showSuccess(
          'Thêm thể loại thành công',
          'Thành công',
          3000
        );
        this.router.navigateByUrl('/categories');
      },
      () => {
        this.notificationService.showError(
          'Thêm thể loại thất bại',
          'Thất bại',
          3000
        );
        this.router.navigateByUrl('/categories');
      }
    );
  }

  onUpdate() {
    const cate = {
      Id: this.category.id,
      name: this.form.name.value.toString().trim()
    };
    this.categoryService.updateCategory(cate).subscribe(
      () => {
        this.notificationService.showSuccess(
          'Sửa thể loại thành công',
          'Thành công',
          3000
        );
        this.router.navigateByUrl('/categories');
      },
      () => {
        this.notificationService.showError(
          'Sửa thể loại thất bại',
          'Thất bại',
          3000
        );
        this.router.navigateByUrl('/categories');
      }
    );
  }

  cancel() {
    return this.router.navigateByUrl('/categories');
  }
}
