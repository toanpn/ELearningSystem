export interface Credentials {
  userName: string;
  token: string;
  type?: SCHEME_TYPE;
}
export enum SCHEME_TYPE {
  BASIC = 'Basic',
  BEARER = 'Bearer',
  NO_SCHEME = ''
}
