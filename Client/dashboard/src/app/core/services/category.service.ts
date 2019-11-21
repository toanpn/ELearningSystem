import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

const router = {
  getAll: 'http://localhost:60793/api/Category/GetAllCategories',
  createCategory: `http://localhost:60793/api/Category/AddCategory`,
  getCategory: `http://localhost:60793/api/Category/GetCategory?Id=`,
  updateCategory: `http://localhost:60793/api/Category/UpdateCategory`,
  deleteCategory: `http://localhost:60793/api/Category/DeleteCategory?Id=`,
};

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  constructor(private http: HttpClient) { }

  loadListCategories(): Observable<any> {
    return this.http.get(router.getAll);
  }

  createCategory(category?: {
    name: string;
  }): Observable<any> {
    return this.http.post(router.createCategory, category);
  }

  updateCategory(category?: {
    name: string;
    Id: number;
  }): Observable<any> {
    return this.http.post(router.updateCategory, category);
  }

  loadCategory(filter: { id: string }): Observable<any> {
    return this.http.get(`${router.getCategory}` + `${filter.id}`);
  }

  deleteCategory(filter: { id: number }): Observable<any> {
    console.log(filter.id);
    console.log(`${router.deleteCategory}` + `${filter.id}`);
    return this.http.get(`${router.deleteCategory}` + `${filter.id}`);
  }
}
