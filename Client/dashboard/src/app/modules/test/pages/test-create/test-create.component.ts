import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder } from '@angular/forms';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { TestService } from 'src/app/core/services/test.service';

@Component({
  selector: 'app-test-create',
  templateUrl: './test-create.component.html',
  styleUrls: ['./test-create.component.scss']
})
export class TestCreateComponent implements OnInit {
  formData: FormGroup;
  isUpdate = false;
  test: any;
  constructor(
    private formBuilder: FormBuilder,
    private testService: TestService,
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
      name: '',
      time: 0
    });
  }

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      if (params.id) {
        this.getTest(params.id);
        this.isUpdate = true;
      }
    });
  }

  getTest(id: any) {
    const filter = {
      id
    };
    this.testService.loadTest(filter).subscribe(res => {
      this.test = res;
      this.setValueForm(this.test);
      this.isUpdate = true;
    });
  }

  setValueForm(test: any) {
    this.formData.patchValue({
      name: test.name
    });
  }

  onCreate() {
    const cate = {
      name: this.form.name.value.toString().trim(),
      time: this.form.time.value
    };
    this.testService.createTest(cate).subscribe(
      () => {
        this.notificationService.showSuccess(
          'Thêm bài kiểm tra thành công',
          'Thành công',
          3000
        );
        this.router.navigateByUrl('/categories');
      },
      () => {
        this.notificationService.showError(
          'Thêm thể bài kiểm tra thất bại',
          'Thất bại',
          3000
        );
        this.router.navigateByUrl('/categories');
      }
    );
  }

  onUpdate() {
    const te = {
      Id: this.test.id,
      name: this.form.name.value.toString().trim(),
      time: this.form.time.value
    };
    this.testService.updateTest(te).subscribe(
      () => {
        this.notificationService.showSuccess(
          'Sửa thể bài kiểm tra thành công',
          'Thành công',
          3000
        );
        this.router.navigateByUrl('/categories');
      },
      () => {
        this.notificationService.showError(
          'Sửa bài kiểm thất bại',
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
