import { Answer } from './Answer.model';

export class Question {
    Id: number;
    Content: string;
    CorrectAnswer: string;
    TestId: number;
    Anwsers: Answer[];
    IndexNum: number;
}
