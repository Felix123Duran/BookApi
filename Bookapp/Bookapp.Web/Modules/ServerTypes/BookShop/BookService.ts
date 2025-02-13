import { ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { BookParametros } from "../Modules/BookShop.Book.BookParametros";
import { BooksRequest } from "../Modules/BookShop.Book.BooksRequest";
import { DeleteRequest } from "../Services/DeleteRequest";
import { DeleteResponse } from "../Services/DeleteResponse";
import { ListRequest } from "../Services/ListRequest";
import { ListResponse } from "../Services/ListResponse";
import { RetrieveRequest } from "../Services/RetrieveRequest";
import { RetrieveResponse } from "../Services/RetrieveResponse";
import { SaveRequest } from "../Services/SaveRequest";
import { SaveResponse } from "../Services/SaveResponse";
import { BookRow } from "./BookRow";

export namespace BookService {
    export const baseUrl = 'BookShop/Book';

    export declare function Create(request: SaveRequest<BookRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<BookRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<BookRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<BookRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<BookRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<BookRow>>;
    export declare function ejecutarAPI(request: BooksRequest, onSuccess?: (response: BookParametros) => void, opt?: ServiceOptions<any>): PromiseLike<BookParametros>;

    export const Methods = {
        Create: "BookShop/Book/Create",
        Update: "BookShop/Book/Update",
        Delete: "BookShop/Book/Delete",
        Retrieve: "BookShop/Book/Retrieve",
        List: "BookShop/Book/List",
        ejecutarAPI: "BookShop/Book/ejecutarAPI"
    } as const;

    [
        'Create', 
        'Update', 
        'Delete', 
        'Retrieve', 
        'List', 
        'ejecutarAPI'
    ].forEach(x => {
        (<any>BookService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}