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
import { forEach } from '@angular/router/src/utils/collection';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.scss']
})
export class TestComponent implements OnInit {
  private destroyed$ = new Subject();
  // id chapter
  private idChapter: number;

  private idTest: any;
  formData: FormGroup;

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
        this.idChapter = id;
        this.loadTest(id);
      } else {
        this._router.navigate(['/chapter', this.idChapter]);
      }
    });
  }

  setValueToForm(test: any) {
    this.idTest = test.Id;
    this.formData.patchValue({
      name: test.Name,
      time: test.Time
    });
  }

  createTest() {
    this._testService.createTest({ Name: 'Bài kiểm tra', Time: 45, ChapterId: this.idChapter })
      .subscribe(test => {
        if (test !== undefined) {
          this.loadTest(this.idChapter);
        }
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
        Id: id
      }).pipe(takeUntil(this.destroyed$), catchError(this.catchError))
      .subscribe(value => {
        if (value == null || value === undefined) {
          this.createTest();
        } else {
          this.setValueToForm(value);
          this.test = value;
          this.loadQuestion(this.test.Id);
        }
      });
  }

  loadQuestion(id: any) {
    this._questionService.loadListQuestions({ Id: id })
      .subscribe(res => {
        this.test.Questions = res;
        for (const item of this.test.Questions) {
          item.Anwsers.sort((a, b) => a.Type.localeCompare(b.Type));
        }
      });
  }

  editMyTest() {
    this._testService.updateTest({
      Id: this.idTest,
      Name: this.form.name.value,
      Time: this.form.time.value,
      ChapterId: this.idChapter
    }).subscribe(() => {
      this._notificationService.showSuccess(
        'Cập nhật thành công',
        'Thành Công',
        3000
      );
    });
  }

  deleteTest(test) {
    this._testService.deleteTest({ Id: test.Id }).subscribe(res => {
      this._notificationService.showSuccess(
        'Xóa bài kiểm tra thành công',
        'Thành Công',
        3000
      );
      this.loadTest(this.idChapter);
    });
  }

  removeQuestion(question: any) {
    this._questionService.deleteQuestion({
      Id: question.id
    }).subscribe(res => {
      this.loadTest(this.idChapter);
      this._notificationService.showSuccess(
        'Xóa thành công',
        'Thành công',
        3000
      );
    });
  }

  editQuestion(question: any) {
    this._router.navigateByUrl(`/question-business?id=${question.Id}&idTest=${this.test.Id}&idChapter=${this.idChapter}`);
  }

  addQuestion() {
    this._router.navigateByUrl(`/question-business?idTest=${this.test.Id}&idChapter=${this.idChapter}`);
  }

  catchError(err: any) {
    return of(null);
  }
}
