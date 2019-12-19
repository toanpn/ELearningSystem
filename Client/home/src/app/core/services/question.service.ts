import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
const router = {
  getQuestions: `http://localhost:60793/api/test/`,
  submitTest: `http://localhost:60793/api/test/check/`
};
@Injectable({
  providedIn: 'root'
})
export class QuestionService {
  constructor(private http: HttpClient) {}

  loadQuestions(courseId: number, chapterId: number) {
    const uri = `${router.getQuestions}${courseId}/${chapterId}`;
    return this.http.get(uri);
  }

  createSubmitTest(courseId: number, chapterId: number, data: any) {
    const uri = `${router.submitTest}${courseId}/${chapterId}`;
    return this.http.post(uri, data);
  }
}
