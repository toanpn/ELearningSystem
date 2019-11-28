import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { UserService } from 'src/app/core/services/user.service';
import { UserModel } from 'src/app/core/models/user.model';
import { ResponseModel } from 'src/app/core/models/response.model';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.scss']
})
export class ContactComponent implements OnInit {
  formData: FormGroup;

  constructor(
    private userService: UserService,
    private formBuilder: FormBuilder
  ) {
    this.initForm();
   }

  ngOnInit() {
    this.getUser();
  }

  get form() {
    return this.formData.controls;
  }

  initForm() {
    this.formData = this.formBuilder.group({
      email: '',
      name: '',
      title: '',
      content: '',
    });
  }

  getUser() {
    this.userService.getCurrentUser()
          .subscribe((res: ResponseModel<UserModel>) => {
              if (res.StatusCode === 200) {
                this.formData = this.formBuilder.group({
                  email: res.Data.Email,
                  name: res.Data.Name
                });
              }
          });
  }
}
