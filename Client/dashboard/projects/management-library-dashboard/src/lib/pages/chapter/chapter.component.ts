import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit, Injector, OnDestroy } from '@angular/core';
import { MatDialog } from '@angular/material';
import { ChapterFormDialogComponent } from '../../components/chapter-form-dialog/chapter-form-dialog.component';
import { AppConfig, PageModel, BaseComponent } from '@management-library/core';
import { LessonFormDialogComponent } from '../../components/lesson-form-dialog/lesson-form-dialog.component';
import { DashboardSandboxService } from '../../dashboard.sandbox';
import { ChapterService } from '@management-library/api';
import { Subject, of } from 'rxjs';
import { takeUntil, catchError } from 'rxjs/operators';

@Component({
  selector: 'app-chapter',
  templateUrl: './chapter.component.html',
  styleUrls: ['./chapter.component.scss']
})
export class ChapterComponent extends BaseComponent
  implements OnInit, OnDestroy {
  listChapter: any[];
  constructor(
    injector: Injector,
    private chapterService: ChapterService,
    private route: ActivatedRoute,
    public dialog: MatDialog,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private dashBoardSandboxService: DashboardSandboxService
  ) {
    super(injector);
    this.listChapter = new Array();
  }

  courseId: any;

  private destroyed$ = new Subject();

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.courseId = params.get('courseId');
      if (this.courseId) {
        this.loadChaptersByCourseId(this.courseId);
      }
    });
    this.updatePageTitle();
  }

  ngOnDestroy() {
    this.destroyed$.next();
    this.destroyed$.complete();
  }

  loadChaptersByCourseId(courseId: any) {
    const loadChapters$ = this.chapterService
      .loadChaptersByCourseId(+courseId)
      .pipe(takeUntil(this.destroyed$), catchError(this.catchError));
    loadChapters$.subscribe(res => {
      this.listChapter = res.Data;
    });
  }

  onCreateNewChapter() {
    const dialogRef = this.dialog.open(ChapterFormDialogComponent, {
      width: '800px',
      data: {
        title: 'Thêm mới',
        actionType: AppConfig.ActionType.INSERT,
        courseId: this.courseId
      }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.listChapter.push(result.data);
      }
    });
  }
  onCreateLesson(index: number) {
    const dialogRef = this.dialog.open(LessonFormDialogComponent, {
      width: '800px'
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.listChapter[index].Lessons = this.listChapter[index].Lessons
          ? this.listChapter[index].Lessons
          : [];
        this.listChapter[index].Lessons.push(result.data);
      }
    });
  }

  onCreateChapters() {
    const createChapters$ = this.chapterService
      .createChapters({
        Chapters: this.listChapter
      })
      .pipe(takeUntil(this.destroyed$), catchError(this.catchError));
    createChapters$.subscribe(() => {
      this.router.navigateByUrl('/app/dashboard/manager-course');
    });
  }

  private updatePageTitle() {
    const page = this.activatedRoute.snapshot.data as PageModel;
    this.titlePage = page.title;
    this.dashBoardSandboxService.setTitle(`${this.titlePage}`);
    this.setTitle(`${this.titlePage}`);
  }

  private catchError(err) {
    return of(null);
  }
}
