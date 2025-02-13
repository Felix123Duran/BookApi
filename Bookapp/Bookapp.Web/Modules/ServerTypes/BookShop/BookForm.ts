import { PrefixedContext, initFormType } from "@serenity-is/corelib";
import { StringEditor, IntegerEditor, DateEditor } from "serenity.corelib";

export interface BookForm {
    Title: StringEditor;
    Description: StringEditor;
    PageCount: IntegerEditor;
    PublishDate: DateEditor;
    Excerpt: StringEditor;
}

export class BookForm extends PrefixedContext {
    static readonly formKey = 'BookShop.Book';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!BookForm.init)  {
            BookForm.init = true;

            var w0 = StringEditor;
            var w1 = IntegerEditor;
            var w2 = DateEditor;

            initFormType(BookForm, [
                'Title', w0,
                'Description', w0,
                'PageCount', w1,
                'PublishDate', w2,
                'Excerpt', w0
            ]);
        }
    }
}