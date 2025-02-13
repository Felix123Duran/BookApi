using Serenity.ComponentModel;
using System;
using System.ComponentModel;

namespace Bookapp.BookShop.Columns;

[ColumnsScript("BookShop.Book")]
[BasedOnRow(typeof(BookRow), CheckNames = true)]
public class BookColumns
{
    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
    public int Id { get; set; }
    [EditLink]
    public string Title { get; set; }
    public string Description { get; set; }
    public int PageCount { get; set; }
    public DateTime PublishDate { get; set; }
    public string Excerpt { get; set; }
}