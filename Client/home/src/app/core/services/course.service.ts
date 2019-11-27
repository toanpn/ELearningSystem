import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
// import { relative } from 'path';

const router = {
    getAll: 'http://localhost:60793/api/Course/GetAllCourse',
    getAllByTime: 'http://localhost:60793/api/Course/GetAllCourse',
    getAllByRate: 'http://localhost:60793/api/Course/GetAllCourse',
    getById: 'http://localhost:60793/api/Course/idCourse='
};

@Injectable({
  providedIn: 'root'
})
export class CourseService {
  constructor(private http: HttpClient) {}

  loadAllCourse(): Observable<any> {
    return this.http.get(router.getAll);
  }

  loadCourseById(id: number): Observable<any>{
    return this.http.get(router.getById + id);
  }

  loadAllCourseNew(): Observable<any> {
    return this.http.get(router.getAllByTime);
  }

  loadAllCourseHot(): Observable<any> {
    return this.http.get(router.getAllByRate);
  }
}
