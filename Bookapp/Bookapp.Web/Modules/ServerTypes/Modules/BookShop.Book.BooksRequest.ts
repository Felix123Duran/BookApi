import { ServiceResponse } from "../Services/ServiceResponse";

export interface BooksRequest extends ServiceResponse {
    id?: number;
    title?: string;
    description?: string;
    pageCount?: number;
    excerpt?: string;
    publishDate?: string;
}