using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPMS.Model.Dto.Salarys;
using EPMS.Service.Services.SalaryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPMS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryService _service;
        public SalaryController(ISalaryService service)
        {
            _service = service;
        }

        /// <summary>
        /// 添加工资
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(AddSalaryDto model)
        {
            var result = await _service.CreateAsync(model);
            return Ok(result);
        }

        /// <summary>
        /// 分页查询工资
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("QueryPagin")]
        public async Task<IActionResult> QueryPaginAsync(SelectSalaryDto model)
        {

            var result = await _service.QueryPaginAsync(model);

            return Ok(result);
        }

        /// <summary>
        /// 删除工资
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