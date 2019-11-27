import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

const router = {
  getAll: 'http://localhost:60793/api/Category/GetAllCategories'
};

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  constructor(private http: HttpClient) {}

  loadAllCategory(): Observable<any> {
    return this.http.get(router.getAll);
  }
}
