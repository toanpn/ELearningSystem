import { Injectable } from '@angular/core';
import { ApiService } from './api-service';
import {
  mapToHttpParamsQuery,
  mapToFormData,
  fmt
} from '@management-library/core';
const router = {
  categoryPaging: `/api/Category/GetAllCategories`,
  createCategory: `/api/Category/AddCategory`,
  updateCategory: `/api/Category/UpdateCategory`
};
@Injectable()
export class CategoryService {
  constructor(private httpClient: ApiService) {}

  loadCategories(filter?: { pageSize: string; pageNumber: string }) {
    const params = mapToHttpParamsQuery(filter);
    return this.httpClient.get(router.categoryPaging, params);
  }

  createNewCategory(data: {
    Name: string
  }) {
    const formData = mapToFormData(data);
    return this.httpClient.postFormData(router.createCategory, data);
  }

  updateCategory(
    data: {
      Name: string
    }
  ) {
    const formData = mapToFormData(data);
    return this.httpClient.postFormData(router.updateCategory, formData);
  }
}
