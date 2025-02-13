import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { BookRow } from "./BookRow";

export interface BookColumns {
    Id: Column<BookRow>;
    Title: Column<BookRow>;
    Description: Column<BookRow>;
    PageCount: Column<BookRow>;
    PublishDate: Column<BookRow>;
    Excerpt: Column<BookRow>;
}

export class BookColumns extends ColumnsBase<BookRow> {
    static readonly columnsKey = 'BookShop.Book';
    static readonly Fields = fieldsProxy<BookColumns>();
}