import {MatPaginatorIntl} from '@angular/material';

/*
* @description: Change default text in angular material pageable
* @author: nam.pham@boot.ai
* @created: 15 July 2019
* */
export class MatPaginatorIntlVN extends MatPaginatorIntl {

  itemsPerPageLabel = 'Số phần tử của trang';
  nextPageLabel = 'Trang tiếp theo';
  previousPageLabel = 'Trang trước';

  getRangeLabel = (page, pageSize, length) => {
    if (length === 0 || pageSize === 0) {
      return '0 trong ' + length;
    }
    length = Math.max(length, 0);
    const startIndex = page * pageSize;
    // If the start index exceeds the list length, do not try and fix the end index to the end.
    const endIndex = startIndex < length ?
      Math.min(startIndex + pageSize, length) :
      startIndex + pageSize;
    return startIndex + 1 + ' - ' + endIndex + ' trong ' + length;
  }
}
