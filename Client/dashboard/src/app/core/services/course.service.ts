import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HttpClientHelper } from '../../shared/HttpClientHelper';

const router = {
  getAll: `${HttpClientHelper.baseURL}/api/Course/GetAllCourse`,
  createCourse: `${HttpClientHelper.baseURL}/api/Course/AddCourse`,
  getCourse: `${HttpClientHelper.baseURL}/api/Course?idCourse=`,
  updateCourse: `${HttpClientHelper.baseURL}/api/Course/UpdateCourse`,
  deleteCourse: `${HttpClientHelper.baseURL}/api/Course/DeleteCourse`
};

@Injectable({
  providedIn: 'root'
})
export class CourseService {
  constructor(private http: HttpClient) { }

  loadListCourses(): Observable<any> {
    return this.http.get(router.getAll);
  }

  createCourse(course?: {
    Name: string;
    Description: string;
    ImageUrl: string;
    CategoryId: number;
    Price: number;
    IsVisible: boolean
  }): Observable<any> {
    return this.http.post(router.createCourse, course);
  }

  updateCourse(course?: {
    name: string;
    description: string;
    image_url: string;
    category_id: number;
    price: number;
    is_visiable: boolean
  }): Observable<any> {
    return this.http.post(router.updateCourse, course);
  }

  loadCourse(filter: { id: string }): Observable<any> {
    return this.http.get(`${router.getCourse} + ${filter.id}`);
  }

  deleteCourse(id: number): Observable<any> {
    return this.http.get(`${router.deleteCourse}?idCourse=${id}`);
  }
}
