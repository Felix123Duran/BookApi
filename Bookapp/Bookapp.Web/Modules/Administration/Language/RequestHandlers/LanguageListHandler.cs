using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Bookapp.Administration.LanguageRow>;
using MyRow = Bookapp.Administration.LanguageRow;


namespace Bookapp.Administration;
public interface ILanguageListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class LanguageListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ILanguageListHandler
{
    public LanguageListHandler(IRequestContext context)
         : base(context)
    {
    }
}