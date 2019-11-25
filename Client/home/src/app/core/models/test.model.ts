import { Question } from './question.model';

export class Test {
    id: number;
    name: string;
    time: number;
    // tslint:disable-next-line:variable-name
    chapter_id: number;
    questions: Question[];
}
