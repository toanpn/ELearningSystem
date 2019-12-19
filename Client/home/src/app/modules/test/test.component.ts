import { NotificationService } from './../../shared/services/notification.service';
import { Observable, Subject } from 'rxjs';
import { QuestionService } from './../../core/services/question.service';
import { Component, OnInit, OnChanges } from '@angular/core';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.scss']
})
export class TestComponent implements OnInit, OnChanges {
  courseId: number;
  chapterId: number;
  indexNumber = 0;
  test: any;
  result: any;
  isSubmit = false;
  filter: any[] = [];

  private destroyed$ = new Subject();
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private questionService: QuestionService,
    private notificationService: NotificationService
  ) {
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        this.route.queryParams.subscribe(params => {
          if (
            !(
              this.courseId === this.route.snapshot.params.courseId &&
              this.chapterId === this.route.snapshot.params.chapterId
            )
          ) {
            this.courseId = this.route.snapshot.params.courseId;
            this.chapterId = this.route.snapshot.params.chapterId;

            this.loadQuestions(this.courseId, this.chapterId);
          }
        });
      }
    });
  }

  ngOnInit() {}

  ngOnChanges() {
    this.destroyed$.next();
    this.destroyed$.complete();
  }

  loadQuestions(courseId: number, chapterId: number) {
    const test$ = this.questionService
      .loadQuestions(courseId, chapterId)
      .pipe(takeUntil(this.destroyed$));
    test$.subscribe((res: any) => {
      this.test = res.Data;
    });
  }

  onNextQuestion() {
    if (this.test.Questions.length - 1 > this.indexNumber) {
      this.indexNumber = this.indexNumber + 1;
    }
  }
  onPrevQuestion() {
    if (this.indexNumber > 0) {
      this.indexNumber = this.indexNumber - 1;
    }
  }

  onChooseQuestion(answer, id, index) {
    const data = {
      QuestionId: id,
      Key: answer
    };
    if (this.filter[index]) {
      this.filter[index] = data;
    } else {
      this.filter.push(data);
    }
  }

  onSubmitTest() {
    this.isSubmit = true;
    this.questionService
      .createSubmitTest(this.courseId, this.chapterId, this.filter)
      .subscribe((res: any) => {
        if (res.Code === 200) {
          this.result = `Bạn đã trả lời đúng ${res.Data} câu`;
          this.notificationService.showSuccess(
            `Bạn đã trả lời đúng ${res.Data} câu`,
            res.Message,
            5000
          );
        }
      });
  }
}
