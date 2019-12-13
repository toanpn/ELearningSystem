import { Answer } from './answer.model';

export class Question {
    constructor(id: number, testId: number, correctAns: string, content: string) {
        this.Id = id;
        this.TestId = testId;
        this.CorrectAnswer = correctAns;
        this.Content = content;
    }
    TestId: number;
    CorrectAnswer: string;
    IndexNum: number;
    Content: string;
    Id: number;
    Anwsers: Answer[];
}
