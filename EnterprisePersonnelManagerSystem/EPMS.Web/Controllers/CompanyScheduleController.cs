using System.Threading.Tasks;
using EPMS.Model.Dto.CompanySchedules;
using EPMS.Service.Services.CompanyScheduleService;
using Microsoft.AspNetCore.Mvc;

namespace EPMS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyScheduleController : ControllerBase
    {
        private readonly ICompanyScheduleService _service;
        public CompanyScheduleController(ICompanyScheduleService service)
        {
            _service = service;
        }

        /// <summary>
        /// 添加职位信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(AddCompanyScheduleDto model)
        {
            var result = await _service.CreateAsync(model);
            return Ok(result);
        }

        /// <summary>
        /// 编辑职位信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> OutStock(EditCompanyScheduleDto model, int id)
        {
            var result = await _service.EditAsync(model, id);
            return Ok(result);
        }

        /// <summary>
        /// 分页查询职位信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("QueryPagin")]
        public async Task<IActionResult> QueryPaginAsync(SelectCompanyScheduleDto model)
        {

            var result = await _service.QueryAsync(model);

            return Ok(result);
        }

        /// <summary>
        /// 删除职位信息
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