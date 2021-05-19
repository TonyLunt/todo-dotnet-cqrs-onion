using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ToDo.Application.Common.Exceptions;

namespace ToDo.Api.Attributes
{
    /// <summary>
    /// Used to filter for our custom excpetions
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// Overrides native exception functionality to add in behaviors for our custom exceptions 
        /// </summary>
        /// <param name="context">The exception context</param>
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is NotFoundException)
            {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Result = new JsonResult(new
                {
                    error = new[] { context.Exception.Message }
                });
            }

            base.OnException(context);
        }
    }
}
