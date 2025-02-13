using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Bookapp.Administration.RoleRow>;
using MyRow = Bookapp.Administration.RoleRow;


namespace Bookapp.Administration;
public interface IRoleListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class RoleListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IRoleListHandler
{
    public RoleListHandler(IRequestContext context)
         : base(context)
    {
    }
}