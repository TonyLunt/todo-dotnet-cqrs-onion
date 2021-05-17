using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Application.Services.UserService
{
    public class UserAuthContext
    {
        public Guid UniqueIdentifier { get; set; }
        public string UserName { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
