using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Bookapp.Administration.LanguageRow>;
using MyRow = Bookapp.Administration.LanguageRow;


namespace Bookapp.Administration;
public interface ILanguageRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }
public class LanguageRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, ILanguageRetrieveHandler
{
    public LanguageRetrieveHandler(IRequestContext context)
         : base(context)
    {
    }
}