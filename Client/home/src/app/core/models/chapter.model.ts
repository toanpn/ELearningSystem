import { Test } from './test.model';
import { Lesson } from './lesson.model';

export class Chapter {
    Id: number;
    Name: string;
    IndexNum: number;
    CourseId: number;
    Tests: Test[];
    Lessons: Lesson[];
}
