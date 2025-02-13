using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Bookapp.BookShop.BookRow>;
using MyRow = Bookapp.BookShop.BookRow;

namespace Bookapp.BookShop;

public interface IBookListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class BookListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IBookListHandler
{
    public BookListHandler(IRequestContext context)
            : base(context)
    {
    }
}