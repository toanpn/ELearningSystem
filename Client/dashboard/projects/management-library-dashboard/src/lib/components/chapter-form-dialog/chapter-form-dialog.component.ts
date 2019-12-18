import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-chapter-form-dialog',
  templateUrl: './chapter-form-dialog.component.html',
  styleUrls: ['./chapter-form-dialog.component.scss']
})
export class ChapterFormDialogComponent implements OnInit {
  formData: FormGroup;
  constructor(
    public dialogRef: MatDialogRef<ChapterFormDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private formBuilder: FormBuilder
  ) {
    this.initializedForm();
  }

  ngOnInit() {
    if (this.data) {
      this.setValueForm(this.data);
    }
  }

  onSubmitForm() {
    this.dialogRef.close({ data: this.formData.value });
  }

  private initializedForm() {
    this.formData = this.formBuilder.group({
      CourseId: [0],
      Name: ['', [Validators.required]],
      IndexNumber: [1]
    });
  }

  private setValueForm(data: any) {
    this.formData.patchValue({
      CourseId: +data.courseId
    });
  }
}
