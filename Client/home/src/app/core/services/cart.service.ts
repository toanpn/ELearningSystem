import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Cart } from '../models/cart.model';

const router = {
  getAll: 'http://localhost:60793/api/Cart/GetAllCart',
  addCart: 'http://localhost:60793/api/Cart/AddCart',
  removeCart: 'http://localhost:60793/api/Cart/DeleteCart?Id=',
  getNumberCart: 'http://localhost:60793/api/Cart/GetNumber',
};

@Injectable({
  providedIn: 'root'
})
export class CartService {
  constructor(private http: HttpClient) {}

  loadAllCart(): Observable<any> {
    return this.http.get(router.getAll);
  }

  addCart(filter: {IdCourse: any}): Observable<any> {
    return this.http.post(router.addCart, filter);
  }

  removeCart(filter: {Id: any}): Observable<any> {
    return this.http.get(`${router.removeCart}` + `${filter.Id}`);
  }

  getNumberCart(): Observable<any> {
    return this.http.get(`${router.getNumberCart}`);
  }
}
