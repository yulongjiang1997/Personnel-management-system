using EPMS.Model;
using EPMS.Service.Services.AdminService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPMS.Web.ActionFilter
{
    public class PermissionActionFillter : ActionFilterAttribute
    {
        private readonly IAdminService _service;
        public  PermissionActionFillter(IAdminService service)
        {
            _service = service;
        }
        public override  void OnActionExecuting(ActionExecutingContext context)
        {
            HttpRequest request = context.HttpContext.Request;
            var isLoing=request.Path.Value.Contains("Login");
            if (!isLoing) {
                var token = request.Headers["Token"].ToString();
                var email = request.Headers["UserEmail"].ToString();
                if (!_service.CheckTokenTimeOut(email, token))
                {
                    context.Result = new JsonResult(new ControllerReturnData<object>
                    {
                        Message = "Error 401 No Access",
                        Success = false,
                    });
                    context.HttpContext.Response.StatusCode = 401;
                }
                base.OnActionExecuting(context);
            }
        }
    }
    public class NoCheck: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }
    }
}
