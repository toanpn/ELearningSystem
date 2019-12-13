import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { Inject } from '@angular/core';
@Component({
  selector: 'app-chapter-dialog',
  templateUrl: './chapter-dialog.component.html'
})
export class ChapterDialogComponent implements OnInit {
  chapterForm: FormGroup;
  @Output() emitChapter = new EventEmitter();
  constructor(
    private formBuilder: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public CourseId: number,
    public dialogRef: MatDialogRef<ChapterDialogComponent>, ) { }

  ngOnInit() {
    this.initForm();
  }
  initForm() {
    this.chapterForm = this.formBuilder.group({
      Name: '',
      IndexNum: '',
    });
  }

  onSubmit() {
    if (this.chapterForm.invalid) {
      return;
    }
    const value = { ...this.chapterForm.value, CourseId: this.CourseId };
    this.dialogRef.close({...value});
  }


}
