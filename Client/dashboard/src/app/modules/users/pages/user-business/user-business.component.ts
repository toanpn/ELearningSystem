import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from './../../../../core/services/user.service';
import { NotificationService } from './../../../../shared/services/notification.service';

@Component({
  selector: 'app-user-business',
  templateUrl: './user-business.component.html',
  styleUrls: ['./user-business.component.scss']
})
export class UserBusinessComponent implements OnInit {
  formData: FormGroup;
  isUpdate = false;
  user: any;
  constructor(
    private formBuilder: FormBuilder,
    private userService: UserService,
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
      email: '',
      userName: '',
      phone: '',
      gender: true,
      address: '',
      dateOfBirth: ''
    });
  }
  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      if (params.id) {
        this.getUser(params.id);
        this.isUpdate = true;
      }
    });
  }

  getUser(id: any) {
    const filter = {
      id
    };
    this.userService.loadUser(filter).subscribe(res => {
      this.user = res.results;
      this.setValueForm(this.user);
      this.isUpdate = true;
    });
  }

  setValueForm(user: any) {
    this.formData.patchValue({
      email: user.Email || '',
      userName: user.UserName || '',
      phone: user.PhoneNumber || '',
      gender: user.gender === 1 ? true : false || true,
      address: user.address || '',
      dateOfBirth: user.birth_day || ''
    });
  }

  onCreate() {
    const user = {
      Email: this.form.email.value.toString().trim(),
      PhoneNumber: this.form.phone.value.toString().trim(),
      Address: this.form.address.value.toString().trim(),
      Gender: this.form.gender.value,
      UserName: this.form.userName.value.toString().trim(),
      BirthDay: this.form.dateOfBirth.value.toString().trim()
    };
    this.userService.createUser(user).subscribe(
      () => {
        this.notificationService.showSuccess(
          'Thêm người dùng thành công',
          'Thành công',
          3000
        );
        this.router.navigateByUrl('/users');
      },
      () => {
        this.notificationService.showError(
          'Thêm người dùng thất bại',
          'Thất bại',
          3000
        );
        this.router.navigateByUrl('/users');
      }
    );
  }

  onUpdate() {
    const user = {
      Id: this.user.Id,
      Email: this.form.email.value.toString().trim(),
      PhoneNumber: this.form.phone.value.toString().trim(),
      Address: this.form.address.value.toString().trim(),
      Gender: this.form.gender.value,
      UserName: this.form.userName.value.toString().trim(),
      BirthDay: this.form.dateOfBirth.value.toString().trim()
    };
    this.userService.updateUser(user).subscribe(
      () => {
        this.notificationService.showSuccess(
          'Sửa thông tin người dùng thành công',
          'Thành công',
          3000
        );
        this.router.navigateByUrl('/users');
      },
      () => {
        this.notificationService.showError(
          'Sửa thông tin người dùng thất bại',
          'Thất bại',
          3000
        );
        this.router.navigateByUrl('/users');
      }
    );
  }

  cancel() {
    return this.router.navigateByUrl('/users');
  }
}
