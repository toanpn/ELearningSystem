import { TokenModel } from './../../models/token.model';
import { VariablesConstant } from './../../constants/variables.constant';
import {HttpClient} from '@angular/common/http';

import {Injectable} from '@angular/core';
import {BehaviorSubject, Observable} from 'rxjs';
import {map} from 'rxjs/operators';
import { URLConstant } from '../../constants/url.constant';
import { ResponseModel } from '../../models/response.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  public currentUser: Observable<string>;
  private currentUserSubject: BehaviorSubject<string>;

  constructor(private  http: HttpClient) {
    const accessToken = AuthService.getAccessToken();
    this.currentUserSubject = new BehaviorSubject<string>(JSON.parse(accessToken));
    this.currentUser = this.currentUserSubject.asObservable();
  }

  static getAccessToken(): string {
    return localStorage.getItem(VariablesConstant.ACCESS_TOKEN);
  }

  login(username: string, password: string) {
    const json = {
      username,
      password
    };
    return this.http.post<any>(URLConstant.LOGIN_URL, json)
      .pipe(map((res: ResponseModel<TokenModel>) => {
        if (res.code === 200) {
          localStorage.setItem(VariablesConstant.ACCESS_TOKEN, JSON.stringify(res.data.accessToken));
          this.currentUserSubject.next(res.data.accessToken);
        }
        return res;
      }));
  }

  logout() {
    // remove access token
    localStorage.removeItem(VariablesConstant.ACCESS_TOKEN);
  }

  getUserFromAccessToken(): Observable<any> {
    return this.http.get('');
  }
}
