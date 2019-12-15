import { Injectable } from '@angular/core';
import { ApiService } from './api-service';
import {
  mapToHttpParamsQuery,
  mapToFormData,
  fmt
} from '@management-library/core';
const router = {
  coursePaging: `/api/course/page`,
  createCourse: `/api/course/create`,
  updateCourse: `/api/course/update/{courseId}`
};
@Injectable()
export class CourseService {
  constructor(private httpClient: ApiService) {}

  loadListCourseAdvanced(filter?: { pageSize: string; pageNumber: string }) {
    const params = mapToHttpParamsQuery(filter);
    return this.httpClient.get(router.coursePaging, params);
  }

  createNewCourse(data: {
    Name: string;
    Description: string;
    Price: number;
    CategoryId: number;
    ImageUrl: any;
  }) {
    const formData = mapToFormData(data);
    return this.httpClient.postFormData(router.createCourse, formData);
  }

  updateCourse(
    data: {
      Name: string;
      Description: string;
      Price: number;
      CategoryId: number;
      ImageUrl: any;
    },
    courseId: number
  ) {
    const uri = fmt(router.updateCourse, { courseId });
    const formData = mapToFormData(data);
    return this.httpClient.putFormData(uri, formData);
  }
}
