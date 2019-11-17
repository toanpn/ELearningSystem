import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

const router = {
  getAll: 'http://localhost:60793/api/User/GetAllUser',
  createUser: `http://localhost:60793/api/User/AddUser`,
  getUser: `http://localhost:60793/api/User?idUser=`,
  updateUser: `http://localhost:60793/api/User/UpdateUser`,
  addRole: `http://localhost:60793/api/UserRole/AddUserRole`
};

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient) {}

  loadListUsers(): Observable<any> {
    return this.http.get(router.getAll);
  }

  createUser(user?: {
    Email: string;
    PhoneNumber: string;
    address: string;
    gender: boolean;
    UserName: string;
    birth_day: string;
  }): Observable<any> {
    return this.http.post(router.createUser, user);
  }

  updateUser(user?: {
    Email: string;
    PhoneNumber: string;
    address: string;
    gender: boolean;
    UserName: string;
    birth_day: string;
    Id: number;
  }): Observable<any> {
    return this.http.post(router.updateUser, user);
  }

  loadUser(filter: { id: string }): Observable<any> {
    return this.http.get(`${router.getUser} + ${filter.id}`);
  }

  addRole(data: { UserId: number; RoleId: number }): Observable<any> {
    return this.http.post(router.addRole, data);
  }
}
