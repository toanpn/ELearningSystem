import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
// import { relative } from 'path';

const router = {
    getAll: 'http://localhost:60793/api/Course/GetAllCourse',
    getCourseNew: 'http://localhost:60793/api/Course/GetCoursesNewPageResult',
    getCourseHot: 'http://localhost:60793/api/Course/GetCoursesHotPageResult',
    getCourseFree: 'http://localhost:60793/api/Course/GetCoursesHotPageResult',
    getCoursePage: 'http://localhost:60793/api/Course/GetPageResult',
    searchCourse: 'http://localhost:60793/api/Course/SearchPageResult',
    getCourseByCategory: 'http://localhost:60793/api/Course/GetCourseByCategory'
};

@Injectable({
  providedIn: 'root'
})
export class CourseService {
  constructor(private http: HttpClient) {}

  loadAllCourse(): Observable<any> {
    return this.http.get(router.getAll);
  }

  loadCoursesPageResults(filter: {pageSize: any, pageNumber: any}): Observable<any> {
    return this.http.get(router.getCoursePage +
      `?pageSize=${filter.pageSize}` +
      `&pageNumber=${filter.pageNumber}`);
  }

  loadAllCourseNew(filter: {pageSize: any, pageNumber: any}): Observable<any> {
    return this.http.get(router.getCourseNew +
      `?pageSize=${filter.pageSize}` +
      `&pageNumber=${filter.pageNumber}`);
  }

  loadAllCourseHot(filter: {pageSize: any, pageNumber: any}): Observable<any> {
    return this.http.get(router.getCourseHot +
      `?pageSize=${filter.pageSize}` +
      `&pageNumber=${filter.pageNumber}`);
  }

  loadAllCourseFree(filter: {pageSize: any, pageNumber: any}): Observable<any> {
    return this.http.get(router.getCourseFree +
      `?pageSize=${filter.pageSize}` +
      `&pageNumber=${filter.pageNumber}`);
  }

  searchCourse(filter: {keyword: string, pageSize: any, pageNumber: any}): Observable<any> {
    return this.http.get(`${router.searchCourse}` +
    `?keyword=${filter.keyword}` +
    `&pageSize=${filter.pageSize}` +
    `&pageNumber=${filter.pageNumber}`);
  }

  loadCourseByCategory(filter: {id: any, pageSize: any, pageNumber: any}): Observable<any> {
    return this.http.get(`${router.getCourseByCategory}` +
    `?id=${filter.id}` +
    `&pageSize=${filter.pageSize}` +
    `&pageNumber=${filter.pageNumber}`);
  }
}
