import { Component, OnInit, Output, EventEmitter, ViewChild, Input } from '@angular/core';
import { Chapter } from './../../../../core/models/chapter.model';
import { MatDialog } from '@angular/material/dialog';
import { ChapterDialogComponent } from './chapter-dialog/chapter-dialog.component';
import { LessonDialogComponent } from './lesson-dialog/lesson-dialog.component';
import { Router } from '@angular/router';
import { CourseService } from './../../../../core/services/course.service';
import { NotificationService } from './../../../../shared/services/notification.service';
import { merge, forkJoin } from 'rxjs';
@Component({
  selector: 'app-add-lesson-chapter',
  templateUrl: './add-lesson-chapter.component.html',
  styles: [
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
  isUpdate = false;
  constructor(
    public dialog: MatDialog,
    private router: Router,
    private courseService: CourseService,
    private notificationService: NotificationService) { }

  ngOnInit() {
  }

  openChapterDialog() {
    const cssConfig = {
      height: '250px',
      width: '600px',
    };
    const dialogRef = this.dialog.open(ChapterDialogComponent, { ...cssConfig, data: this.CourseId });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.lstChapter.push(result);
      }
    });
  }

  openLessonDialog(index) {
    const cssConfig = {
      height: '500px',
      width: '600px',
    };
    const dialogRef = this.dialog.open(LessonDialogComponent, { ...cssConfig, data: index });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        // tslint:disable-next-line:max-line-length
        this.lstChapter[index].Lessons = this.lstChapter[index].Lessons ? this.lstChapter[index].Lessons : [];
        this.lstChapter[index].Lessons.push(result);
      }
    });
  }
  cancel() {
    return this.router.navigateByUrl('/courses');
  }

  createPostStream(chapter) {
    return this.courseService.createChapter(this.lstChapter[0]);
  }

  onCreate() {
    const lstStream$ = [];
    this.lstChapter.forEach((chapter) => {
      lstStream$.push(this.createPostStream(chapter));
    });
    forkJoin(...lstStream$)
      .subscribe(
        () => {
          this.notificationService.showSuccess(
            'Thêm mới nôi dung học thành công',
            'Thành công',
            2000
          );
          this.next.emit();
        },
        () => {
          this.notificationService.showError(
            'Thêm người dùng thất bại',
            'Thất bại',
            4000
          );
        }
      );
  }
}

