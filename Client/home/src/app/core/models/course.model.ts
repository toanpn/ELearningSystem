import { Chapter } from './chapter.model';

export class Course {
    id: number;
    name: string;
    description: string;
    price: number;
    // tslint:disable-next-line:variable-name
    image_url: string;
    // tslint:disable-next-line:variable-name
    is_visiable: boolean;
    // tslint:disable-next-line:variable-name
    category_id: number;
    chapters: Chapter[];
}
