export interface ResponseModel<T> {
    StatusCode: number;
    ResponseMessage: string;
    Data: T;
}
