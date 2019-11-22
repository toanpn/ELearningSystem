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
  private id: any;

  test$: Observable<any>;

  constructor(
    private _router: Router,
    private _notificationService: NotificationService,
    private _testService: TestService,
    private _activatedRouter: ActivatedRoute,
    private _questionService: QuestionService,
    private _answerService: AnswerService
  ) {
  }

  ngOnInit() {
    this._activatedRouter.params.subscribe(par => {
      let id = par['id'];
      if (id) {
        this.id = id;
        this.loadListTest(id);
      } else {
        this._router.navigate(['/chapter']);
      }
    });

    this.test$.subscribe(value => {
      if (value == null || value == undefined) {
        this._router.navigate(['/test-create', this.id]);
      }
    })
  }

  ngOnDestroy() {
    this.destroyed$.next();
    this.destroyed$.complete();
    this.destroyed$.unsubscribe();
  }

  loadListTest(id: any) {
    this.test$ = this._testService
      .loadListTests({
        id: id
      })
      .pipe(takeUntil(this.destroyed$), catchError(this.catchError));
  }

  editTest(test) {
    this._router.navigateByUrl(`/category-business?id=${test.id}`);
  }

  deleteTest(test) {
    this._testService
      .deleteTest({ id: test.id })
      .subscribe(res => {
        this._notificationService.showSuccess(
          "Xóa bài kiểm tra thành công",
          "Thành Công",
          3000
        );
        this.loadListTest(this.id);
      });
  }

  catchError(err: any) {
    console.log(err);
    return of(null);
  }
}
