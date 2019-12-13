import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

const router = {
  getAllAnswer: 'http://localhost:60793/api/Answer/GetAllAnswerByQuestion?id=',
  createAnswer: `http://localhost:60793/api/Answer/AddAnswer`,
  getAnswer: `http://localhost:60793/api/Answer/GetAnswer?Id=`,
  updateAnswer: `http://localhost:60793/api/Answer/UpdateAnswer`,
  deleteAnswer: `http://localhost:60793/api/Answer/DeleteAnswer?Id=`,
};

@Injectable({
  providedIn: 'root'
})
export class AnswerService {
  constructor(private http: HttpClient) { }

  loadListAnswers(filter: {
    Id: string
  }): Observable<any> {
    return this.http.get(`${router.getAllAnswer}` + `${filter.Id}`);
  }

  createAnswer(value?: {
    Content: string;
    Type: string;
    QuestionId: number;
  }): Observable<any> {
    return this.http.post(router.createAnswer, value);
  }

  updateAnswer(value?: {
    Content: string;
    Type: string;
    QuestionId: number;
    Id: number;
  }): Observable<any> {
    return this.http.post(router.updateAnswer, value);
  }

  loadAnswer(filter: { Id: string }): Observable<any> {
    return this.http.get(`${router.getAnswer}` + `${filter.Id}`);
  }

  deleteAnswer(filter: { Id: number }): Observable<any> {
    return this.http.get(`${router.deleteAnswer}` + `${filter.Id}`);
  }
}
