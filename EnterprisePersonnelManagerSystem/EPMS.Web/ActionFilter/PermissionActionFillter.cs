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
    public class PermissionActionFillter : IActionFilter
    {
        private readonly IAdminService _service;
        public PermissionActionFillter(IAdminService service)
        {
            _service = service;
        }

        public async void OnActionExecuted(ActionExecutedContext context)
        {



        }

        public async void OnActionExecuting(ActionExecutingContext context)
        {
            HttpRequest request = context.HttpContext.Request;
            var token = request.Headers["Token"].ToString();
            var UserId = request.Headers["UserId"].ToString();
            if (await _service.CheckTokenTimeOutAsync(UserId, token))
            {
                context.Result = new JsonResult(new ControllerReturnData<object>
                {
                    Message = "Error 401 No Access",
                    Success = false,
                });
            }
        }
    }
}
