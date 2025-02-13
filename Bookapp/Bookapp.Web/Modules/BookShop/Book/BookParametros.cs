namespace Bookapp.Modules.BookShop.Book;

public class BookParametros: ServiceRequest
{
    public int id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public int pageCount { get; set; }
    public string excerpt { get; set; }
    public DateTime publishDate { get; set; }
}
