using MyRequest = Serenity.Services.SaveRequest<Bookapp.Administration.LanguageRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Bookapp.Administration.LanguageRow;


namespace Bookapp.Administration;
public interface ILanguageSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }
public class LanguageSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ILanguageSaveHandler
{
    public LanguageSaveHandler(IRequestContext context)
         : base(context)
    {
    }
}