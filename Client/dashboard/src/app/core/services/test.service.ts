import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

const router = {
  getAllByChapter: 'http://localhost:60793/api/Test/GetTestByChapter?id=',
  createTest: `http://localhost:60793/api/Test/AddTest`,
  getTest: `http://localhost:60793/api/Test/GetTest?Id=`,
  updateTest: `http://localhost:60793/api/Test/UpdateTest`,
  deleteTest: `http://localhost:60793/api/Test/DeleteTest?Id=`
};

@Injectable({
  providedIn: 'root'
})
export class TestService {
  constructor(private http: HttpClient) { }

  loadListTests(filter: {
    Id: string
  }): Observable<any> {
    return this.http.get(`${router.getAllByChapter}` + `${filter.Id}`);
  }

  createTest(test?: {
    Name: string;
    Time: number;
    ChapterId: any;
  }): Observable<any> {
    return this.http.post(router.createTest, test);
  }

  updateTest(test?: {
    Name: string;
    Id: number;
    Time: any;
    ChapterId: any;
  }): Observable<any> {
    return this.http.post(router.updateTest, test);
  }

  loadTest(filter: { Id: string }): Observable<any> {
    return this.http.get(`${router.getTest}` + `${filter.Id}`);
  }

  deleteTest(filter: { Id: number }): Observable<any> {
    return this.http.get(`${router.deleteTest}` + `${filter.Id}`);
  }
}
