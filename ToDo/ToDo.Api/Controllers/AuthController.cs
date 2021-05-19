using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Application.Services.UserService;

namespace ToDo.Api.Controllers
{
    public class AuthController : BaseController
    {
        private IUserService _userService;
        public AuthController(IMediator mediator, IUserService userService) : base(mediator)
        {
            _userService = userService;
        }
        
        [HttpGet]
        public ActionResult<UserAuthContext> Get()
        {
            var response = _userService.GetUserAuthContext();
            return Ok(response);
        }
    }
}
