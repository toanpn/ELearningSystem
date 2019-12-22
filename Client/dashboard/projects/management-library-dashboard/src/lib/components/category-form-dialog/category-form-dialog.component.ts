import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { AppConfig } from '@management-library/core';

@Component({
  selector: 'app-category-form-dialog',
  templateUrl: './category-form-dialog.component.html',
})
export class CategoryFormDialogComponent implements OnInit {
  title = 'Thêm mới';
  category: any;
  formData: FormGroup;
  fileImage: any;
  baseUrl: any;
  constructor(
    public dialogRef: MatDialogRef<CategoryFormDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private formBuilder: FormBuilder
  ) {
    this.initializedForm();
    this.baseUrl = AppConfig.BASE_URL.dev;
  }

  ngOnInit() {
    this.setValuesForm();
  }

  onSubmitForm() {
    const data = {
      Name: this.formData.controls.Name.value,
    };
    this.dialogRef.close(data);
  }

  private setValuesForm() {
    if (this.data) {
      if (this.data.category) {
        this.category = this.data.category;
      }
      if (this.data.actionType) {
        if (this.data.actionType === AppConfig.ActionType.UPDATE) {
          this.title = 'Cập nhập';
          this.formData.patchValue({
            Name: this.data.category.Name,
          });
        }
      }

    }
  }

  private initializedForm() {
    this.formData = this.formBuilder.group({
      Name: ['', [Validators.required]],
    });
  }
}
