import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-lesson-form-dialog',
  templateUrl: './lesson-form-dialog.component.html',
  styleUrls: ['./lesson-form-dialog.component.scss']
})
export class LessonFormDialogComponent implements OnInit {
  formData: FormGroup;
  constructor(
    private formBuilder: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public ChapterId: number,
    public dialogRef: MatDialogRef<LessonFormDialogComponent>
  ) {}

  ngOnInit() {
    this.initializedForm();
  }

  onSubmitForm() {
    if (this.formData.invalid) {
      return;
    } else {
      this.dialogRef.close({ data: this.formData.value });
    }
  }

  private initializedForm() {
    this.formData = this.formBuilder.group({
      Name: ['', [Validators.required]],
      Description: ['', [Validators.required]],
      VideoUrl: ['', [Validators.required]],
      VideoTime: ['', [Validators.required]]
    });
  }
}
