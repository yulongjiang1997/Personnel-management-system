using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPMS.Model.Dto.Departments;
using EPMS.Service.Services.DepartmentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPMS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _service;
        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }

        /// <summary>
        /// 添加部门信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(AddDepartmentDto model)
        {
            var result = await _service.CreateAsync(model);
            return Ok(result);
        }

        /// <summary>
        /// 编辑部门信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> OutStock(EditDepartmentDto model, int id)
        {
            var result = await _service.EditAsync(model, id);
            return Ok(result);
        }

        /// <summary>
        /// 分页查询部门信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("QueryPagin")]
        public async Task<IActionResult> QueryPaginAsync(SelectDeparmentDto model)
        {

            var result = await _service.QueryAsync(model);

            return Ok(result);
        }

        /// <summary>
        /// 删除部门信息
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