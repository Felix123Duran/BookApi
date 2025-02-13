using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Bookapp.Administration.UserRow>;
using MyRow = Bookapp.Administration.UserRow;


namespace Bookapp.Administration;
public interface IUserRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }
public class UserRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IUserRetrieveHandler
{
    public UserRetrieveHandler(IRequestContext context)
         : base(context)
    {
    }
}