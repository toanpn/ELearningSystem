import { map } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import {
  HttpHeaders,
  HttpParams,
  HttpClient,
  HttpResponse
} from '@angular/common/http';
@Injectable()
export class ApiService {
  private httpHeaders = new HttpHeaders();

  private httpOptions = {};

  constructor(private httpClient: HttpClient) {
    this.httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json; charset=utf-8',
        'Access-Control-Allow-Origin': '*',
        'Cache-Control': 'no-cache'
      })
    };
    this.httpHeaders = new HttpHeaders(this.httpOptions);
  }

  get(uri: string, params?: HttpParams) {
    return this.httpClient
      .get(uri, { headers: this.httpHeaders, params })
      .pipe(map(this.extractData));
  }

  post(uri: string, data?: any, params?: HttpParams) {
    return this.httpClient
      .post(uri, data, {
        headers: this.httpHeaders,
        params
      })
      .pipe(map(this.extractData));
  }

  // api post method form-data
  postFormData(uri: string, data?: any, params?: HttpParams) {
    return this.httpClient
      .post(uri, data, {
        params
      })
      .pipe(map(this.extractData));
  }

  delete(uri: string, params?: HttpParams) {
    return this.httpClient
      .delete(uri, {
        headers: this.httpHeaders,
        params
      })
      .pipe(map(this.extractData));
  }

  put(uri: string, data?: any, params?: HttpParams) {
    return this.httpClient
      .put(uri, data, { headers: this.httpHeaders, params })
      .pipe(map(this.extractData));
  }

  // api put method form-data
  putFormData(uri: string, data?: any, params?: HttpParams) {
    return this.httpClient
      .put(uri, data, {
        params
      })
      .pipe(map(this.extractData));
  }

  private extractData(res: HttpResponse<object>) {
    const body = res;
    return body || {};
  }
}
