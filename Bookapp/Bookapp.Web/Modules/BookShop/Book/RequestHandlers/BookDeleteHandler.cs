using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Bookapp.BookShop.BookRow;

namespace Bookapp.BookShop;

public interface IBookDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> { }

public class BookDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IBookDeleteHandler
{
    public BookDeleteHandler(IRequestContext context)
            : base(context)
    {
    }
}