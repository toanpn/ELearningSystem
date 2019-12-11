import { Component, OnInit, ViewChild, TemplateRef, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { Observable } from 'rxjs';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { CategoryService } from 'src/app/core/services/category.service';
import { CourseService } from 'src/app/core/services/course.service';

@Component({
  selector: 'app-add-course',
  templateUrl: './add-course.component.html'
})
export class AddCourseComponent implements OnInit {

  formData: FormGroup;
  isUpdate = false;
  course: any;
  @Output() next = new EventEmitter();

  categories$: Observable<any>;
  constructor(
    private formBuilder: FormBuilder,
    private courseService: CourseService,
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
      name: '',
      category_id: '',
      image_url: '',
      description: '',
      price: ''
    });
  }
  ngOnInit() {
    this.getListCategories();
    this.route.queryParams.subscribe(params => {
      if (params.id) {
        this.getCourse(params.id);
        this.isUpdate = true;
      }
    });
  }

  getListCategories() {
    this.categoryService.loadListCategories().subscribe(res => {
      this.categories$ = res;
    });
  }

  getCourse(id: any) {
    const filter = {
      id
    };
    this.courseService.loadCourse(filter).subscribe(res => {
      this.course = res.results;
      this.setValueForm(this.course);
      this.isUpdate = true;
    });
  }

  setValueForm(course: any) {
    this.formData.patchValue({
      name: course.name || '',
      price: course.price || 1,
      description: course.description || '',
      image_url: course.image_url || '',
      category_id: course.category_id || null
    });
  }

  onCreate() {
    const course = {
      Name: this.form.name.value.toString().trim(),
      Price: this.form.price.value === null ? 1 : this.form.price.value,
      Description: this.form.description.value.toString().trim(),
      ImageUrl: this.form.image_url.value === '' ?
        'https://www.xosothantai.com/attachments/1a5c21338cb1172cb57214a3f3548874-gif.167602/' : this.form.image_url.value,
      CategoryId: +this.form.category_id.value,
      IsVisible: false,
      User_Course: [
        {
          user_id: 1,
          isowner: true,
          datetime: new Date().toLocaleTimeString()
        }
      ]
    };
    this.courseService.createCourse(course).subscribe(
      () => {
        this.notificationService.showSuccess(
          'Thêm khóa học thành công',
          'Thành công',
          2000
        );
        this.next.emit();
      },
      () => {
        this.notificationService.showError(
          'Thêm người dùng thất bại',
          'Thất bại',
          4000
        );
        this.router.navigateByUrl('/courses');
      }
    );
  }

  onUpdate() {
    const course = {
      Id: this.course.Id,
      Email: this.form.email.value.toString().trim(),
      PhoneNumber: this.form.phone.value.toString().trim(),
      address: this.form.address.value.toString().trim(),
      gender: this.form.gender.value,
      CourseName: this.form.courseName.value.toString().trim(),
      birth_day: this.form.dateOfBirth.value.toString().trim()
    };
    // this.courseService.updateCourse(course).subscribe(
    //   () => {
    //     this.notificationService.showSuccess(
    //       'Sửa thông tin người dùng thành công',
    //       'Thành công',
    //       3000
    //     );
    //     this.router.navigateByUrl('/courses');
    //   },
    //   () => {
    //     this.notificationService.showError(
    //       'Sửa thông tin người dùng thất bại',
    //       'Thất bại',
    //       3000
    //     );
    //     this.router.navigateByUrl('/courses');
    //   }
    // );
  }

  cancel() {
    return this.router.navigateByUrl('/courses');
  }

}
