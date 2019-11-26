import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

const router = {
    getAll: 'http://localhost:60793/api/Course/GetAllCourse',
    getAllByTime: 'http://localhost:60793/api/Course/GetAllCourse',
    getAllByRate: 'http://localhost:60793/api/Course/GetAllCourse',
};

@Injectable({
  providedIn: 'root'
})
export class CourseService {
  constructor(private http: HttpClient) {}

  loadAllCourse(): Observable<any> {
    return this.http.get(router.getAll);
  }

  loadAllCourseNew(): Observable<any> {
    return this.http.get(router.getAllByTime);
  }

  loadAllCourseHot(): Observable<any> {
    return this.http.get(router.getAllByRate);
  }
}
