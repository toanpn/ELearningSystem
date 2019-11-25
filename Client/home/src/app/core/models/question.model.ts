import { Answer } from './Answer.model';

export class Question {
    id: number;
    content: string;
    // tslint:disable-next-line:variable-name
    correct_answer: string;
    // tslint:disable-next-line:variable-name
    test_id: number;
    answers: Answer[];
}
