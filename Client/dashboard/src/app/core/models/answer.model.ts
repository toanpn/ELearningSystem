export class Answer {
  [x: string]: any;
  constructor(id: number, content: string, type: string, questionId: number) {
    this.Id = id;
    this.Content = content;
    this.Type = type;
    this.QuestionId = questionId;
  }
  Id: number;
  Content: string;
  Type: string;
  QuestionId: number;
}
