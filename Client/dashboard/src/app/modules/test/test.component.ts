import { Component, OnInit } from '@angular/core';
import { Subject, Observable, of } from 'rxjs';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { Router, ActivatedRoute } from '@angular/router';
import { takeUntil, catchError } from 'rxjs/operators';
import { TestService } from 'src/app/core/services/test.service';
import { QuestionService } from 'src/app/core/services/question.service';
import { AnswerService } from 'src/app/core/services/answer.service';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.scss']
})
export class TestComponent implements OnInit {
  private destroyed$ = new Subject();
  // id chapter
  private id: any;

  private idTest: any;

  test$: Observable<any>;
  questions$: Observable<any>;

  constructor(
    // tslint:disable-next-line:variable-name
    private _router: Router,
    // tslint:disable-next-line:variable-name
    private _notificationService: NotificationService,
    // tslint:disable-next-line:variable-name
    private _testService: TestService,
    // tslint:disable-next-line:variable-name
    private _activatedRouter: ActivatedRoute,
    // tslint:disable-next-line:variable-name
    private _questionService: QuestionService,
    // tslint:disable-next-line:variable-name
    private _answerService: AnswerService
  ) {
  }

  ngOnInit() {
    this._activatedRouter.params.subscribe(par => {
      const id = par.id;
      console.log(id);
      if (id) {
        this.id = id;
        this.loadTest(id);
      } else {
        this._router.navigate(['/chapter']);
      }
    });

    this.test$.subscribe(value => {
      console.log(value);
      if (value == null || value === undefined) {
        this.createTest();
      }
    });
  }

  createTest() {
    this._testService.createTest({ name: 'Bài kiểm tra', time: 45, chapter_id: this.id })
      .subscribe(res => {

      });
  }

  loadAllQuestion() {
    console.log('load question');
    // tslint:disable-next-line:max-line-length
    this.questions$ = this._questionService
      .loadListQuestions({ id: this.idTest })
      .pipe(takeUntil(this.destroyed$), catchError(this.catchError));
  }

  // tslint:disable-next-line:use-life-cycle-interface
  ngOnDestroy() {
    this.destroyed$.next();
    this.destroyed$.complete();
    this.destroyed$.unsubscribe();
  }

  loadTest(id: any) {
    this.test$ = this._testService
      .loadListTests({
        id
      })
      .pipe(takeUntil(this.destroyed$), catchError(this.catchError));
  }

  editTest(test) {
    this._router.navigateByUrl(`/test-create?id=${test.id}`);
  }

  deleteTest(test) {
    this._testService
      .deleteTest({ id: test.id })
      .subscribe(res => {
        this._notificationService.showSuccess(
          'Xóa bài kiểm tra thành công',
          'Thành Công',
          3000
        );
        this.loadTest(this.id);
      });
  }

  catchError(err: any) {
    console.log(err);
    return of(null);
  }
}
