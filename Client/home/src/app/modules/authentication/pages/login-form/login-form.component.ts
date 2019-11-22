import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.scss']
})
export class LoginFormComponent implements OnInit {
  formData: FormGroup;
  hide = true;

  @Output() submitForm: EventEmitter<any> = new EventEmitter<any>();

  constructor(private formBuilder: FormBuilder) {}

  ngOnInit() {
    this.initializedForm();
  }

  onSubmitLogin() {
    if (this.formData.valid) {
      this.submitForm.emit({ formData: this.formData.value });
    }
  }

  private initializedForm() {
    this.formData = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
      remember: [false, null]
    });
  }
}
