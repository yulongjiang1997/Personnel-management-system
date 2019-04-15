using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EPMS.Web.ActionFilter
{
    public class ExceptionFiltering : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result =  new ApplicationErrorResult("Error:"+context.Exception.Message);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.ExceptionHandled = true;
        }
    }

    public class ApplicationErrorResult : ObjectResult
    {
        public ApplicationErrorResult(object value) : base(value)
        {
            StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }
}
