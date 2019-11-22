import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HttpClientHelper } from '../../shared/HttpClientHelper';

const router = {
  getAll: `${HttpClientHelper.baseURL}/api/Category/GetAllCategory`,
  createCategory: `${HttpClientHelper.baseURL}/api/Category/AddCategory`,
  getCategory: `${HttpClientHelper.baseURL}/api/Category?idCategory=`,
  updateCategory: `${HttpClientHelper.baseURL}/api/Category/UpdateCategory`,
};

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  constructor(private http: HttpClient) { }

  loadListCategories(): Observable<any> {
    console.log(router.getAll);
    return this.http.get(router.getAll);
  }

  createCategory(category?: {
    Email: string;
    PhoneNumber: string;
    address: string;
    gender: boolean;
    CategoryName: string;
    birth_day: string;
  }): Observable<any> {
    return this.http.post(router.createCategory, category);
  }

  updateCategory(category?: {
    Email: string;
    PhoneNumber: string;
    address: string;
    gender: boolean;
    CategoryName: string;
    birth_day: string;
    Id: number;
  }): Observable<any> {
    return this.http.post(router.updateCategory, category);
  }

  loadCategory(filter: { id: string }): Observable<any> {
    return this.http.get(`${router.getCategory} + ${filter.id}`);
  }
}
