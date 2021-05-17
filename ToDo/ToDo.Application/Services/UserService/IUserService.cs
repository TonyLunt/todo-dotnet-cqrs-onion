using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Application.Services.UserService
{
    public interface IUserService
    {
        string GetUserName();

        UserAuthContext GetUserAuthContext();
    }
}
