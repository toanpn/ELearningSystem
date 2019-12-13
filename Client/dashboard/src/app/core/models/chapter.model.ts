import { Test } from './test.model';
import { Lesson } from './lesson.model';

export class Chapter {
    Name: string;
    CourseId: number;
    Tests: Test[];
    Lessons: Lesson[];
}
