export interface ResponseModel<T> {
    code: number;
    message: string;
    data: T;
}