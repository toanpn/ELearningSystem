import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

const router = {
  authentication: `/token`
};
@Injectable()
export class AuthenticationService {
  constructor(private httpClient: HttpClient) {}

  login(data: { username: string; password: string }) {
    const credentials =
      `username=${data.username}` +
      `&password=${data.password}` +
      '&grant_type=password';
    const reqHeader = new HttpHeaders({
      'Content-Type': 'application/x-www-urlencoded',
      'No-Auth': 'True'
    });
    return this.httpClient.post<any>(
      router.authentication,
      encodeURI(credentials),
      {
        headers: reqHeader
      }
    );
  }
}
