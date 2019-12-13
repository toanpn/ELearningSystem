import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-lesson-dialog',
  templateUrl: './lesson-dialog.component.html'
})
export class LessonDialogComponent implements OnInit {
  lessonForm: FormGroup;
  constructor(
    private formBuilder: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public ChapterId: number,
    public dialogRef: MatDialogRef<LessonDialogComponent>) { }

  ngOnInit() {
    this.initForm();
  }
  initForm() {
    this.lessonForm = this.formBuilder.group({
      Name: '',
      Description: '',
      VideoUrl: '',
      VideoTime: ''
    });
  }

  onSubmit() {
    if (this.lessonForm.invalid) {
      return;
    }
    this.dialogRef.close({...this.lessonForm.value});
  }


}
