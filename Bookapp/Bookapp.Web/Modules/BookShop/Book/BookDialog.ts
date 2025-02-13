import { BookForm, BookRow, BookService } from '@/ServerTypes/BookShop';
import { RolePermissionDialog } from "../Books/RolePermissionDialog";
import { Decorators, EntityDialog, serviceRequest } from '@serenity-is/corelib';

@Decorators.registerClass('Bookapp.BookShop.BookDialog')
export class BookDialog extends EntityDialog<BookRow, any> {
    protected getFormKey() { return BookForm.formKey; }v
    protected getRowDefinition() { return BookRow; }
    protected getService() { return BookService.baseUrl; }

    protected form = new BookForm(this.idPrefix);

    protected getToolbarButtons(): Serenity.ToolButton[] {
        let buttons = super.getToolbarButtons();

        buttons.push({
            title: "Boton de Prueba",
            cssClass: 'aplicar-button',
            icon: 'fa-lock text-green',
            onClick: () => {
                serviceRequest('BookShop/Book/ejecutarAPI', {
                    id: 1
                   
                }, _ => {
                   
                });
            }
        });



        return buttons;
    }
}