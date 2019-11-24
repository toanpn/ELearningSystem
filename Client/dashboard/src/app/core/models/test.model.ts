import { Question } from './question.model';

export interface Test {
    id: number;
    name: string;
    time: number;
    chapter_id: number;
    // vl dat ten :), toafn dat @@
    Questions: Question[];
}
