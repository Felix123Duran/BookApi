using Microsoft.AspNetCore.Mvc;
using Serenity.Web;

namespace Bookapp.BookShop.Pages;

[PageAuthorize(typeof(BookRow))]
public class BookPage : Controller
{
    [Route("BookShop/Book")]
    public ActionResult Index()
    {
        return this.GridPage("@/BookShop/Book/BookPage",
            BookRow.Fields.PageTitle());
    }
}