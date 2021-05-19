using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Application.Services.UserService;

namespace ToDo.Api.Services
{
    public class UserService : IUserService
    {
        private UserAuthContext _authContext;
        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _authContext = new UserAuthContext()
            {
                //TODO: swap out for implementation of unique user ID per auth provider
                UniqueIdentifier = default(Guid),
                UserName = httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "Unauthenticated User",
                IsAuthenticated = httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false
            };
        }
        public UserAuthContext GetUserAuthContext()
        {
            return _authContext;
        }
    }
}
