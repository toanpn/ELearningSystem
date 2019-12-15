import { HttpParams } from '@angular/common/http';
import { FormGroup } from '@angular/forms';

export function fmt<TObject>(text: string, myHash: TObject) {
  let key;
  // tslint:disable-next-line: forin
  for (key in myHash) {
    text = text.replace(new RegExp('\\{' + key + '\\}', 'gm'), myHash[key]);
  }
  return text;
}

export function isEmpty(args: any): boolean {
  return (
    args === null || args === undefined || args === '' || args.length === 0
  );
}

export function isNotEmpty(args: any): boolean {
  return !isEmpty(args);
}

// tslint:disable-next-line: ban-types
export function mapToHttpParamsQuery(params: Object) {
  let httpParams: HttpParams = new HttpParams();
  for (const property in params) {
    if (params.hasOwnProperty(property) && isNotEmpty(params[property])) {
      httpParams = httpParams.set(property, params[property]);
    }
  }
  return httpParams;
}

export function mapToFormData(body: object): FormData {
  const formData = new FormData();
  for (const property in body) {
    if (body.hasOwnProperty(property) && isNotEmpty(body[property])) {
      formData.append(property, body[property]);
    }
  }
  return formData;
}

export function removeTheFirstChar(args: string): string {
  if (isEmpty(args)) {
    return '';
  }
  return args.substring(1, args.length);
}

export function removeTheLastChar(args: string): string {
  if (isEmpty(args)) {
    return '';
  }
  return args.substring(0, args.length - 1);
}

export function isString(object: any): boolean {
  return typeof object === 'string';
}

export function isDecimal(value) {
  const DECIMAL_REGEX = /^\d*\.{1}\d+$/;
  return DECIMAL_REGEX.test(value);
}

export function stringToBoolean(value: string) {
  return value === 'true';
}

export function booleanToString(value: boolean) {
  return value === true ? 'true' : 'false';
}

export function deepCopyObject(source, target) {
  Object.keys(source).forEach(property => {
    target[property] = source[property];
  });
}

export function SearchTree<T>(
  elements: T[],
  prod: string,
  children: string,
  matchingTitle: string
) {
  let result: T[] = [];
  if (elements === undefined) {
    return [];
  }
  result = elements.filter(item => item[prod] === matchingTitle);
  if (result.length === 1) {
    return result;
  }
  result = this.searchTree(result[children], prod, children, matchingTitle);
  return result;
}

export function filterBy<T>(data: T[], prop: string, reversed?: boolean) {
  reversed = !reversed;
  return data.sort(
    (a, b) =>
      // tslint:disable-next-line: triple-equals
      (a[prop] == b[prop] ? 0 : a[prop] < b[prop] ? -1 : 1) *
      (reversed ? -1 : 1)
  );
}

export function compareTwoFormControl(
  controlName: string,
  matchingControlName: string
) {
  return (formGroup: FormGroup) => {
    const control = formGroup.controls[controlName];
    const matchingControl = formGroup.controls[matchingControlName];
    if (!control && !matchingControlName) {
      return;
    }
    if (matchingControl.errors && !matchingControl.errors.mustMatch) {
      return;
    }
    // set error on matchingControl if validation fails
    if (control.value !== matchingControl.value) {
      matchingControl.setErrors({ mustMatch: true });
    } else {
      matchingControl.setErrors(null);
    }
  };
}
