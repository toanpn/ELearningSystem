import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

const router = {
  getAllByTest: 'http://localhost:60793/api/Question/GetAllQuestionByTest?id=',
  createQuestion: `http://localhost:60793/api/Question/AddQuestion`,
  getQuestion: `http://localhost:60793/api/Question/GetQuestion?Id=`,
  updateQuestion: `http://localhost:60793/api/Question/UpdateQuestion`,
  deleteQuestion: `http://localhost:60793/api/Question/DeleteQuestion?Id=`,
  lastIndex: `http://localhost:60793/api/Question/GetLastIndexTest?Id=`,
};

@Injectable({
  providedIn: 'root'
})
export class QuestionService {
  constructor(private http: HttpClient) { }

  loadListQuestions(filter: {
    Id: string
  }): Observable<any> {
    return this.http.get(`${router.getAllByTest}` + `${filter.Id}`);
  }

  createQuestion(value?: {
    TestId: number,
    CorrectAnswer: string,
    IndexNum: number,
    Content: string,
  }): Observable<any> {
    return this.http.post(router.createQuestion, value);
  }

  updateQuestion(value?: {
    TestId: number,
    CorrectAnswer: string,
    IndexNum: number,
    Content: string,
    Id: number;
  }): Observable<any> {
    return this.http.post(router.updateQuestion, value);
  }

  loadQuestion(filter: { Id: string }): Observable<any> {
    return this.http.get(`${router.getQuestion}` + `${filter.Id}`);
  }

  deleteQuestion(filter: { Id: number }): Observable<any> {
    return this.http.get(`${router.deleteQuestion}` + `${filter.Id}`);
  }

  getLastIndexQuestion(filter: { Id: number }): Observable<any> {
    return this.http.get(`${router.lastIndex}` + `${filter.Id}`);
  }
}
