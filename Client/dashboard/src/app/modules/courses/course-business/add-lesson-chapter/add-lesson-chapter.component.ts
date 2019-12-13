import { Component, OnInit, Output, EventEmitter, ViewChild, Input } from '@angular/core';
import { Chapter } from './../../../../core/models/chapter.model';
import { MatDialog } from '@angular/material/dialog';
import { ChapterDialogComponent } from './chapter-dialog/chapter-dialog.component';
import { LessonDialogComponent } from './lesson-dialog/lesson-dialog.component';
@Component({
  selector: 'app-add-lesson-chapter',
  templateUrl: './add-lesson-chapter.component.html',
  styles:[
    `
    .mat-expansion-panel-header-description{
      justify-content:flex-end;
      margin-right: 30px;
    }
    .mat-expansion-panel-header{
      font-weight:bold;
    }
    `
  ]
})
export class AddLessonChapterComponent implements OnInit {
  @Output() next = new EventEmitter();
  lstChapter: Chapter[] = [];
  @Input() CourseId: number;
  @ViewChild(ChapterDialogComponent, { static: true }) chapterDialog;
  constructor(public dialog: MatDialog) { }

  ngOnInit() {
  }

  openChapterDialog() {
    const cssConfig = {
      height: '300px',
      width: '600px',
    };
    const dialogRef = this.dialog.open(ChapterDialogComponent, { ...cssConfig, data: this.CourseId });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.lstChapter.push(result);
      }
    });
  }

  openLessonDialog(index){
    const cssConfig = {
      height: '500px',
      width: '600px',
    };
    console.log(index)
    const dialogRef = this.dialog.open(LessonDialogComponent, { ...cssConfig, data:index });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        // tslint:disable-next-line:max-line-length
        this.lstChapter[index].Lessons = this.lstChapter[index].Lessons ? this.lstChapter[index].Lessons : [];
        this.lstChapter[index].Lessons.push(result);
        console.log(this.lstChapter)
      }
    });
  }
}

