import { Chapter } from './chapter.model';

export class Course {

    constructor(id: number, name: string, des: string, price: number, imageUrl: string, isVisiable: boolean, categoryId: number) {
        this.Id = id;
        this.Name = name;
        this.Description = des;
        this.Price = price;
        this.ImageUrl = imageUrl;
        this.IsVisible = isVisiable;
        this.CategoryId = categoryId;
    }

    Id: number;
    Name: string;
    Description: string;
    Price: number;
    Discount: number;
    ImageUrl: string;
    IsVisible: boolean;
    CategoryId: number;
    Chapters: Chapter[];
    CreateDate: string;
}
