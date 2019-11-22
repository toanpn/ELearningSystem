import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

const router = {
  getAllByQuestion: 'http://localhost:60793/api/Answer/GetAllQuestionByTest?id=',
  createAnswer: `http://localhost:60793/api/Answer/AddQuestion`,
  getAnswer: `http://localhost:60793/api/Answer/GetQuestion?Id=`,
  updateAnswer: `http://localhost:60793/api/Answer/UpdateQuestion`,
  deleteAnswer: `http://localhost:60793/api/Answer/DeleteQuestion?Id=`,
};

@Injectable({
  providedIn: 'root'
})
export class AnswerService {
  constructor(private http: HttpClient) { }

  loadListAnswers(filter: {
    id: string
  }): Observable<any> {
    return this.http.get(`${router.getAllByQuestion}` + `${filter.id}`);
  }

  createAnswer(value?: {
    name: string;
  }): Observable<any> {
    return this.http.post(router.createAnswer, value);
  }

  updateAnswer(value?: {
    name: string;
    Id: number;
  }): Observable<any> {
    return this.http.post(router.updateAnswer, value);
  }

  loadAnswer(filter: { id: string }): Observable<any> {
    return this.http.get(`${router.getAnswer}` + `${filter.id}`);
  }

  deleteAnswer(filter: { id: number }): Observable<any> {
    return this.http.get(`${router.deleteAnswer}` + `${filter.id}`);
  }
}
