import { Question } from './question.model';

export class Test {
    Id: number;
    Name: string;
    Time: number;
    ChapterId: number;
    Questions: Question[];
}
