import { VariablesConstant } from './../../constants/variables.constant';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

const router = {
  token: `http://localhost:60793/token`
};

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  public currentUser: Observable<string>;
  private currentUserSubject: BehaviorSubject<string>;

  constructor(private http: HttpClient) {
    const accessToken = AuthService.getAccessToken();
    this.currentUserSubject = new BehaviorSubject<string>(
      JSON.parse(accessToken)
    );
    this.currentUser = this.currentUserSubject.asObservable();
  }

  static getAccessToken(): string {
    return localStorage.getItem(VariablesConstant.ACCESS_TOKEN);
  }

  login(username: string, password: string) {
    const credentials =
      `username=${username}` + `&password=${password}` + '&grant_type=password';
    const reqHeader = new HttpHeaders({
      'Content-Type': 'application/x-www-urlencoded',
      'No-Auth': 'True'
    });
    return this.http
      .post<any>(router.token, encodeURI(credentials), {
        headers: reqHeader
      })
      .pipe(
        map((res: any) => {
          if (res) {
            localStorage.setItem(
              VariablesConstant.ACCESS_TOKEN,
              JSON.stringify(res.access_token)
            );
            localStorage.setItem('user_name', res.userName);
          }
          return res;
        })
      );
  }

  logout() {
    // remove access token
    localStorage.removeItem(VariablesConstant.ACCESS_TOKEN);
  }

  getUserFromAccessToken(): Observable<any> {
    return this.http.get('');
  }
}
