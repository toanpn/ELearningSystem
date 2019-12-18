import { Injectable } from '@angular/core';
import { ApiService } from './api-service';
import { fmt } from '@management-library/core';

const router = {
  createChapters: `/api/chapter/create`,
  getChaptersByCourseId: `/api/chapter/getbycourseId/{courseId}`
};

@Injectable()
export class ChapterService {
  constructor(private httpClient: ApiService) {}

  createChapters(data: { Chapters: any[] }) {
    return this.httpClient.post(router.createChapters, data);
  }

  loadChaptersByCourseId(courseId: number) {
    const uri = fmt(router.getChaptersByCourseId, { courseId });
    return this.httpClient.get(uri);
  }
}
