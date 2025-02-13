using Serenity.ComponentModel;
using System;

namespace Bookapp.BookShop.Forms;

[FormScript("BookShop.Book")]
[BasedOnRow(typeof(BookRow), CheckNames = true)]
public class BookForm
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int PageCount { get; set; }
    public DateTime PublishDate { get; set; }
    public string Excerpt { get; set; }
}