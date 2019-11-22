import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

const router = {
  getAllByChapter: 'http://localhost:60793/api/Test/GetTestByChapter?id=',
  createTest: `http://localhost:60793/api/Test/AddTest`,
  getTest: `http://localhost:60793/api/Test/GetTest?Id=`,
  updateTest: `http://localhost:60793/api/Test/UpdateTest`,
  deleteTest: `http://localhost:60793/api/Test/DeleteTest?Id=`,
};

@Injectable({
  providedIn: 'root'
})
export class TestService {
  constructor(private http: HttpClient) { }

  loadListTests(filter: {
    id: string
  }): Observable<any> {
    return this.http.get(`${router.getAllByChapter}` + `${filter.id}`);
  }

  createTest(test?: {
    name: string;
    time: number;
    chapter_id: any;
  }): Observable<any> {
    return this.http.post(router.createTest, test);
  }

  updateTest(test?: {
    name: string;
    Id: number;
  }): Observable<any> {
    return this.http.post(router.updateTest, test);
  }

  loadTest(filter: { id: string }): Observable<any> {
    return this.http.get(`${router.getTest}` + `${filter.id}`);
  }

  deleteTest(filter: { id: number }): Observable<any> {
    return this.http.get(`${router.deleteTest}` + `${filter.id}`);
  }
}
