import { Injectable } from '@angular/core';
import { ApiService } from './api-service';
import { mapToHttpParamsQuery } from '@management-library/core';
const router = {
  getAll: `/api/category/all`
};
@Injectable()
export class CategoryService {
  constructor(private httpClient: ApiService) {}

  loadCategories() {
    return this.httpClient.get(router.getAll);
  }
}
