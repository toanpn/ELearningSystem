import { ChapterService } from './services/chapter.service';
import { CategoryService } from './services/category.service';
import { ApiService } from './services/api-service';
import { CourseService } from './services/course.service';
import { AuthenticationService } from './services/authentication-api.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
const providers = [
  AuthenticationService,
  ApiService,
  CourseService,
  CategoryService,
  ChapterService
];
@NgModule({
  declarations: [],
  imports: [CommonModule],
  providers: [...providers]
})
export class ManagementLibraryApiModule {}
