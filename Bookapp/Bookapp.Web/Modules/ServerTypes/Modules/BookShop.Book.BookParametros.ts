import { ServiceRequest } from "../Services/ServiceRequest";

export interface BookParametros extends ServiceRequest {
    id?: number;
    title?: string;
    description?: string;
    pageCount?: number;
    excerpt?: string;
    publishDate?: string;
}