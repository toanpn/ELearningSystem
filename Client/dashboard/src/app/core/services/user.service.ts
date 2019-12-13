import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HttpClientHelper } from '../../shared/HttpClientHelper';

const router = {
  getAll: `${HttpClientHelper.baseURL}/api/User/GetAllUser`,
  createUser: `${HttpClientHelper.baseURL}/api/User/AddUser`,
  getUser: `${HttpClientHelper.baseURL}/api/User?idUser=`,
  updateUser: `${HttpClientHelper.baseURL}/api/User/UpdateUser`,
  addRole: `${HttpClientHelper.baseURL}/api/UserRole/AddUserRole`
};

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient) { }

  loadListUsers(): Observable<any> {
    return this.http.get(router.getAll);
  }

  createUser(user?: {
    Email: string;
    PhoneNumber: string;
    Address: string;
    Gender: boolean;
    UserName: string;
    BirthDay: string;
  }): Observable<any> {
    return this.http.post(router.createUser, user);
  }

  updateUser(user?: {
    Email: string;
    PhoneNumber: string;
    Address: string;
    Gender: boolean;
    UserName: string;
    BirthDay: string;
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
