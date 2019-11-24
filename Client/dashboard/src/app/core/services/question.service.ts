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
  lastId: `http://localhost:60793/api/Question/GetLastId`
};

@Injectable({
  providedIn: 'root'
})
export class QuestionService {
  constructor(private http: HttpClient) { }

  loadListQuestions(filter: {
    id: string
  }): Observable<any> {
    return this.http.get(`${router.getAllByTest}` + `${filter.id}`);
  }

  createQuestion(value?: {
    test_id: number,
    correct_answer: string,
    index_num: number,
    content: string,
  }): Observable<any> {
    return this.http.post(router.createQuestion, value);
  }

  updateQuestion(value?: {
    test_id: number,
    correct_answer: string,
    index_num: number,
    content: string,
    id: number;
  }): Observable<any> {
    return this.http.post(router.updateQuestion, value);
  }

  loadQuestion(filter: { id: string }): Observable<any> {
    return this.http.get(`${router.getQuestion}` + `${filter.id}`);
  }

  deleteQuestion(filter: { id: number }): Observable<any> {
    return this.http.get(`${router.deleteQuestion}` + `${filter.id}`);
  }

  getLastIndexQuestion(filter: { id: number }): Observable<any> {
    return this.http.get(`${router.lastIndex}` + `${filter.id}`);
  }

  getLastIdQuestion(): Observable<any> {
    return this.http.get(`${router.lastId}`);
  }
}
