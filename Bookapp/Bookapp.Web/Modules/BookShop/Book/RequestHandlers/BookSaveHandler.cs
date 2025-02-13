using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<Bookapp.BookShop.BookRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Bookapp.BookShop.BookRow;

namespace Bookapp.BookShop;

public interface IBookSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class BookSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IBookSaveHandler
{
    public BookSaveHandler(IRequestContext context)
            : base(context)
    {
    }
}