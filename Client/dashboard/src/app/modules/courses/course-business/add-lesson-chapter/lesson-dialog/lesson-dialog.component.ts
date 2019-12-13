import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-lesson-dialog',
  templateUrl: './lesson-dialog.component.html'
})
export class LessonDialogComponent implements OnInit {
  lessonForm: FormGroup;
  constructor(
    private formBuilder: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public ChapterId: number,
    public dialogRef: MatDialogRef<LessonDialogComponent>,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.initForm();
  }
  initForm() {
    this.lessonForm = this.formBuilder.group({
      Name: ['', Validators.required],
      Description: ['', Validators.required],
      VideoUrl: ['', Validators.required],
      VideoTime: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.lessonForm.invalid) {
      this.toastr.error('Vui lòng nhập đầy đủ thông tin');
      return;
    }
    this.dialogRef.close({ ...this.lessonForm.value });
  }


}
