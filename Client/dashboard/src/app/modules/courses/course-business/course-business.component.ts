import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { CourseService } from './../../../core/services/course.service';
import { NotificationService } from './../../../shared/services/notification.service';
import { CategoryService } from './../../../core/services/category.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-course-business',
  templateUrl: './course-business.component.html',
  styleUrls: ['./course-business.component.scss']
})
export class CourseBusinessComponent implements OnInit {
  formData: FormGroup;
  isUpdate = false;
  course: any;
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
    console.log(this.form);
    const course = {
      name: this.form.name.value.toString().trim(),
      price: this.form.price.value === null ? 1 : this.form.price.value,
      description: this.form.description.value.toString().trim(),
      image_url: this.form.image_url.value === '' ?
        'https://image.shutterstock.com/image-vector/grunge-red-sample-word-round-260nw-1242668641.jpg' : this.form.image_url.value,
      category_id: this.form.category_id.value,
      is_visiable: false,
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
          'Thêm người dùng thành công',
          'Thành công',
          2000
        );
        this.router.navigateByUrl('/courses');
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
