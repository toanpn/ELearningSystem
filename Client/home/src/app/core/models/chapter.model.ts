import { Test } from './test.model';
import { Lesson } from './lesson.model';

export class Chapter {
    id: number;
    name: string;
    // tslint:disable-next-line:variable-name
    index_num: number;
    // tslint:disable-next-line:variable-name
    course_id: number;
    tests: Test[];
    lessons: Lesson[];
}
