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
    id: string
  }): Observable<any> {
    return this.http.get(`${router.getAllAnswer}` + `${filter.id}`);
  }

  createAnswer(value?: {
    content: string;
    type: string;
    question_id: number;
  }): Observable<any> {
    return this.http.post(router.createAnswer, value);
  }

  updateAnswer(value?: {
    content: string;
    type: string;
    question_id: number;
    id: number;
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
