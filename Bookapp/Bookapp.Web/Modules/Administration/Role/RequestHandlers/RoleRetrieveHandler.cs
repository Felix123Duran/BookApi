using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Bookapp.Administration.RoleRow>;
using MyRow = Bookapp.Administration.RoleRow;


namespace Bookapp.Administration;
public interface IRoleRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }
public class RoleRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IRoleRetrieveHandler
{
    public RoleRetrieveHandler(IRequestContext context)
         : base(context)
    {
    }
}