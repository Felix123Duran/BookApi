import { fieldsProxy } from "@serenity-is/corelib";

export interface BookRow {
    Id?: number;
    Title?: string;
    Description?: string;
    PageCount?: number;
    PublishDate?: string;
    Excerpt?: string;
}

export abstract class BookRow {
    static readonly idProperty = 'Id';
    static readonly nameProperty = 'Title';
    static readonly localTextPrefix = 'BookShop.Book';
    static readonly deletePermission = 'Administration:General';
    static readonly insertPermission = 'Administration:General';
    static readonly readPermission = 'Administration:General';
    static readonly updatePermission = 'Administration:General';

    static readonly Fields = fieldsProxy<BookRow>();
}