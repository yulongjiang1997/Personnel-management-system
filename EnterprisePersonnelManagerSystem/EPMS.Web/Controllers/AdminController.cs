using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPMS.Model;
using EPMS.Model.Dto.Admin;
using EPMS.Service.Services.AdminService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPMS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _service;
        public AdminController(IAdminService service)
        {
            _service = service;
        }

        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody]AdminAddOrEditDto model)
        {
            var result = new ControllerReturnData<bool>();
            result.Obj = await _service.Create(model);
            return Ok(result);
        }

        /// <summary>
        /// 编辑管理员
        /// </summary>
        /// <param name="model"></param>
        ///  <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit(AdminAddOrEditDto model, int id)
        {
            var result = await _service.Edit(model, id);
            return Ok(result);
        }

        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.Delete(id);
            return Ok(result);
        }

        /// <summary>
        /// 管理员登陆
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var result = await _service.Login(model);
            return Ok(result);
        }

    }
}