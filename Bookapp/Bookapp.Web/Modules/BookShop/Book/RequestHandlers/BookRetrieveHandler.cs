using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Bookapp.BookShop.BookRow>;
using MyRow = Bookapp.BookShop.BookRow;

namespace Bookapp.BookShop;

public interface IBookRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class BookRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IBookRetrieveHandler
{
    public BookRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}