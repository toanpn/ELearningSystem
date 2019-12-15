import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { AppConfig } from '@management-library/core';

@Component({
  selector: 'app-course-form-dialog',
  templateUrl: './course-form-dialog.component.html',
  styleUrls: ['./course-form-dialog.component.scss']
})
export class CourseFormDialogComponent implements OnInit {
  title = 'Thêm mới';
  categories: any;
  formData: FormGroup;
  fileImage: any;
  baseUrl: any;
  constructor(
    public dialogRef: MatDialogRef<CourseFormDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private formBuilder: FormBuilder
  ) {
    this.initializedForm();
    this.baseUrl = AppConfig.BASE_URL.dev;
  }

  ngOnInit() {
    this.setValuesForm();
  }

  changeImage(event) {
    if (event.target.files && event.target.files[0]) {
      const reader = new FileReader();
      reader.onload = (e: any) => {
        this.formData.patchValue({
          ImageUrl: e.target.result
        });
      };
      reader.readAsDataURL(event.target.files[0]);
      this.fileImage = event.target.files[0];
    }
  }

  onSubmitForm() {
    const data = {
      Name: this.formData.controls.Name.value,
      Description: this.formData.controls.Description.value,
      Price: this.formData.controls.Price.value,
      CategoryId: this.formData.controls.CategoryId.value,
      ImageUrl: this.fileImage
    };
    this.dialogRef.close(data);
  }

  private setValuesForm() {
    if (this.data) {
      if (this.data.categories) {
        this.categories = this.data.categories;
      }
      if (this.data.actionType) {
        if (this.data.actionType === AppConfig.ActionType.UPDATE) {
          this.title = 'Cập nhập';
        }
      }

      this.formData.patchValue({
        Name: this.data.course.Name,
        Description: this.data.course.Description,
        Price: this.data.course.Price,
        CategoryId: this.data.course.CategoryId,
        ImageUrl: this.baseUrl + this.data.course.ImageUrl
      });
    }
  }

  private initializedForm() {
    this.formData = this.formBuilder.group({
      Name: ['', [Validators.required]],
      Description: [''],
      Price: [0],
      CategoryId: [0, [Validators.required]],
      ImageUrl: ['']
    });
  }
}
