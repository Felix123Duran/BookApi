import { BookForm, BookRow, BookService } from '@/ServerTypes/BookShop';
import { Decorators, EntityDialog } from '@serenity-is/corelib';

@Decorators.registerClass('Bookapp.BookShop.BookDialog')
export class BookDialog extends EntityDialog<BookRow, any> {
    protected getFormKey() { return BookForm.formKey; }
    protected getRowDefinition() { return BookRow; }
    protected getService() { return BookService.baseUrl; }

    protected form = new BookForm(this.idPrefix);
}