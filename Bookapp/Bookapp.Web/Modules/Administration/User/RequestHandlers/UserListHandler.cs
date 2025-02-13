using MyRequest = Bookapp.Administration.UserListRequest;
using MyResponse = Serenity.Services.ListResponse<Bookapp.Administration.UserRow>;
using MyRow = Bookapp.Administration.UserRow;

namespace Bookapp.Administration;
public interface IUserListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class UserListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IUserListHandler
{
    public UserListHandler(IRequestContext context)
         : base(context)
    {
    }
}