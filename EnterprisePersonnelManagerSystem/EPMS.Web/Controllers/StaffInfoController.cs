using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EPMS.Model.Dto.Staffinfos;
using EPMS.Service.Services.StaffInfoService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPMS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffInfoController : ControllerBase
    {
        private readonly IStaffInfoService _service;
        public StaffInfoController(IStaffInfoService service)
        {
            _service = service;
        }

        /// <summary>
        /// 添加员工信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(AddStaffinfoDto model)
        {
            var result = await _service.CreateAsync(model);
            return Ok(result);
        }

        /// <summary>
        /// 编辑员工信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> OutStock(EditStaffinfoDto model, int id)
        {
            var result = await _service.EditAsync(id, model);
            return Ok(result);
        }

        /// <summary>
        /// 分页查询员工信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("QueryPagin")]
        public async Task<IActionResult> QueryPaginAsync(SelectStaffinfoDto model)
        {

            var result = await _service.QueryPaginAsync(model);

            return Ok(result);
        }

        /// <summary>
        /// 删除员工信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return Ok(result);
        }
    }
}