import { Answer } from './answer.model';

export class Question {
    constructor(id: number, testId: number, correctAns: string, content: string) {
        this.id = id;
        this.test_id = testId;
        this.correct_answer = correctAns;
        this.content = content;
    }
    // tslint:disable-next-line:variable-name
    test_id: number;
    // tslint:disable-next-line:variable-name
    correct_answer: string;
    // tslint:disable-next-line:variable-name
    index_num: number;
    content: string;
    id: number;
    Anwsers: Answer[];
}
