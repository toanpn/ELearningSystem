import { Component, OnInit } from '@angular/core';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { FormGroup, FormBuilder } from '@angular/forms';
import { QuestionService } from 'src/app/core/services/question.service';
import { AnswerService } from 'src/app/core/services/answer.service';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { Answer } from 'src/app/core/models/answer.model';
import { Question } from 'src/app/core/models/question.model';

@Component({
  selector: 'app-question-business',
  templateUrl: './question-business.component.html',
  styleUrls: ['./question-business.component.scss']
})
export class QuestionBusinessComponent implements OnInit {

  public Editor = ClassicEditor;
  formData: FormGroup;
  isUpdate = false;
  idTest: any;
  idChapter: any;
  question: Question;
  content: string;
  ansA: string;
  ansB: string;
  ansC: string;
  ansD: string;
  a: Answer;
  b: Answer;
  c: Answer;
  d: Answer;
  correctAnswer: string;
  lastIndex: number;
  constructor(
    private questionService: QuestionService,
    private answerService: AnswerService,
    private notificationService: NotificationService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.correctAnswer = 'A';
    this.content = '';
    this.ansA = '';
    this.ansB = '';
    this.ansC = '';
    this.ansD = '';
    const Editor = ClassicEditor;
  }

  public onReady(editor) {
    editor.ui.getEditableElement().parentElement.insertBefore(
      editor.ui.view.toolbar.element,
      editor.ui.getEditableElement()
    );
  }

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      if (params.id) {
        this.getQuestion(params.id);
        this.isUpdate = true;
      }
      this.idChapter = params.idChapter;
      if (params.idTest) {
        this.idTest = params.idTest;
      } else {
        window.history.back();
      }
    });
  }

  getQuestion(id: any) {
    const filter = {
      Id: id
    };
    this.questionService.loadQuestion(filter).subscribe(res => {
      this.question = res;
      this.content = this.question.Content;
      this.correctAnswer = this.question.CorrectAnswer;
      this.isUpdate = true;
      this.getAnswers(id);
    });
  }

  getAnswers(id: any) {
    this.answerService.loadListAnswers({ Id: id })
      .subscribe(res => {
        this.question.Anwsers = res;
        this.a = this.question.Anwsers.filter(t => t.Type === 'A')[0];
        this.b = this.question.Anwsers.filter(t => t.Type === 'B')[0];
        this.c = this.question.Anwsers.filter(t => t.Type === 'C')[0];
        this.d = this.question.Anwsers.filter(t => t.Type === 'D')[0];
        this.ansA = this.a.Content;
        this.ansB = this.b.Content;
        this.ansC = this.c.Content;
        this.ansD = this.d.Content;
      });
  }

  onCreate() {
    this.question = new Question(1, this.idTest, this.correctAnswer, this.content);
    this.questionService.createQuestion(this.question).subscribe(
      q => {
        if (q !== undefined) {
          this.question.Id = q.Id;
          this.createAnswer();
        }
      },
      () => {
        this.notificationService.showError(
          'Thêm thất bại',
          'Thất bại',
          3000
        );
        this.router.navigateByUrl(`/test/${this.idChapter}`);
      }
    );
  }

  createAnswer() {
    // tslint:disable-next-line:prefer-const
    const observable = Observable.create((observer: Answer) => {
      observer.next(new Answer(1, this.ansA, 'A', this.question.Id));
      observer.next(new Answer(2, this.ansB, 'B', this.question.Id));
      observer.next(new Answer(3, this.ansC, 'C', this.question.Id));
      observer.next(new Answer(4, this.ansD, 'D', this.question.Id));
      observer.complete();
      this.notificationService.showSuccess(
        'Thêm thành công',
        'Thành công',
        3000
      );
      this.router.navigateByUrl(`/test/${this.idChapter}`);
    });

    observable.subscribe((ans: Answer) => {
      this.answerService.createAnswer(ans).subscribe(() => {
      }, () => {
        this.notificationService.showError(
          'Thêm thất bại',
          'Thất bại',
          3000
        );
        this.router.navigateByUrl(`/test/${this.idChapter}`);
      });
    });
  }

  onUpdate() {
    this.question.Content = this.content;
    this.question.CorrectAnswer = this.correctAnswer;
    this.questionService.updateQuestion(this.question).subscribe(
      () => {
        this.updateAnswer();
      },
      () => {
        this.notificationService.showError(
          'Cập nhật thất bại',
          'Thất bại',
          3000
        );
        this.router.navigateByUrl(`/test/${this.idChapter}`);
      }
    );
  }

  updateAnswer() {
    this.a.Content = this.ansA;
    this.b.Content = this.ansB;
    this.c.Content = this.ansC;
    this.d.Content = this.ansD;
    // tslint:disable-next-line:prefer-const
    const o = Observable.create((observer: Answer) => {
      observer.next(this.a);
      observer.next(this.b);
      observer.next(this.c);
      observer.next(this.d);
      observer.complete();
      this.notificationService.showSuccess(
        'Cập nhật công',
        'Thành công',
        3000
      );
      this.router.navigateByUrl(`/test/${this.idChapter}`);
    });

    o.subscribe((ans: Answer) => {
      this.answerService.updateAnswer(ans).subscribe(() => {
      }, () => {
        this.notificationService.showError(
          'Cập nhật thất bại',
          'Thất bại',
          3000
        );
        this.router.navigateByUrl(`/test/${this.idChapter}`);
      }, () => {

      });
    });
  }

  cancel() {
    this.router.navigateByUrl(`/test/${this.idChapter}`);
  }
}
