import { Chapter } from './chapter.model';

export class Course {

    constructor(id: number, name: string, des: string, price: number, imageUrl: string, isVisiable: boolean, categoryId: number){
        this.id = id;
        this.name = name;
        this.description = des;
        this.price = price;
        this.image_url = imageUrl;
        this.is_visiable = isVisiable;
        this.category_id = categoryId;
    }

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
