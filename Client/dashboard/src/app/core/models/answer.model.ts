export class Answer {
  [x: string]: any;
    constructor(id: number, content: string, type: string, questionId: number) {
        this.id = id;
        this.content = content;
        this.type = type;
        this.question_id = questionId;
    }
    id: number;
    content: string;
    type: string;
    // tslint:disable-next-line:variable-name
    question_id: number;
}
