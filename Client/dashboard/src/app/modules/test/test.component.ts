import { Component, OnInit } from '@angular/core';
import { Subject, Observable, of } from 'rxjs';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { Router, ActivatedRoute } from '@angular/router';
import { takeUntil, catchError } from 'rxjs/operators';
import { TestService } from 'src/app/core/services/test.service';
import { QuestionService } from 'src/app/core/services/question.service';
import { AnswerService } from 'src/app/core/services/answer.service';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Test } from 'src/app/core/models/test.model';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.scss']
})
export class TestComponent implements OnInit {
  private destroyed$ = new Subject();
  // id chapter
  private id: number;

  private idTest: any;
  formData: FormGroup;

  // tu sau lam the nay cho do mat cong nhe, ko ép kiểu à
  test: Test;

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
    private _answerService: AnswerService,
    // tslint:disable-next-line:variable-name
    private _formBuilder: FormBuilder
  ) {
    this.initForm();
  }

  initForm() {
    this.formData = this._formBuilder.group({
      name: '',
      time: '0'
    });
  }

  get form() {
    return this.formData.controls;
  }

  ngOnInit() {
    this._activatedRouter.params.subscribe(par => {
      const id = par.id;
      if (id !== undefined) {
        this.id = id;
        this.loadTest(id);
      } else {
        this._router.navigate(['/chapter', this.id]);
      }
    });
  }

  setValueToForm(test: any) {
    this.idTest = test.id;

    this.formData.patchValue({
      name: test.name,
      time: test.time
    });
  }

  createTest() {
    this._testService.createTest({ name: 'Bài kiểm tra', time: 45, chapter_id: this.id })
      .subscribe(o => {
      }, () => { },
        () => {
          this.loadTest(this.id);
        });
  }

  // tslint:disable-next-line:use-life-cycle-interface
  ngOnDestroy() {
    this.destroyed$.next();
    this.destroyed$.complete();
    this.destroyed$.unsubscribe();
  }

  loadTest(id: any) {
    this._testService
      .loadListTests({
        id
      }).pipe(takeUntil(this.destroyed$), catchError(this.catchError))
      .subscribe(value => {
        if (value == null || value === undefined) {
          this.createTest();
        } else {
          this.setValueToForm(value);
          this.test = value;
        }
      });
  }

  editMyTest() {
    this._testService.updateTest({
      Id: this.idTest,
      name: this.form.name.value,
      time: this.form.time.value,
      chapter_id: this.test.chapter_id
    }).subscribe(() => {
      this._notificationService.showSuccess(
        'Cập nhật thành công',
        'Thành Công',
        3000
      );
    });
  }

  deleteTest(test) {
    this._testService.deleteTest({ id: test.id }).subscribe(res => {
      this._notificationService.showSuccess(
        'Xóa bài kiểm tra thành công',
        'Thành Công',
        3000
      );
      this.loadTest(this.id);
    });
  }

  removeQuestion(question: any) {
    this._questionService.deleteQuestion({
      id: question.id
    }).subscribe(res => {
      this.loadTest(this.id);
      this._notificationService.showSuccess(
        'Xóa thành công',
        'Thành công',
        3000
      );
    });
  }

  editQuestion(question: any) {
    this._router.navigateByUrl(`/question-business?id=${question.id}&idTest=${this.test.id}&idChapter=${this.id}`);
  }

  addQuestion() {
    this._router.navigateByUrl(`/question-business?idTest=${this.test.id}&idChapter=${this.id}`);
  }

  catchError(err: any) {
    return of(null);
  }
}
