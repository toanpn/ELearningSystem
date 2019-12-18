import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
const router = {
  getChaptersByCourseId: `http://localhost:60793/api/chapter/getbycourseId/`
};
@Injectable({
  providedIn: 'root'
})
export class ChapterService {
  constructor(private http: HttpClient) {}

  loadChaptersByCourseId(courseId: number) {
    return this.http.get(`${router.getChaptersByCourseId}${courseId}`);
  }
}
