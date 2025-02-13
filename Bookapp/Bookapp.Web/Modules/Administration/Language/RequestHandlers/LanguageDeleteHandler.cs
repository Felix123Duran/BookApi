using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Bookapp.Administration.LanguageRow;


namespace Bookapp.Administration;
public interface ILanguageDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> { }

public class LanguageDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, ILanguageDeleteHandler
{
    public LanguageDeleteHandler(IRequestContext context)
         : base(context)
    {
    }
}