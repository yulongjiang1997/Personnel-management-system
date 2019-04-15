using System.Threading.Tasks;
using EPMS.Model.Dto.PersonalSchedules;
using EPMS.Service.Services.PersonalScheduleService;
using Microsoft.AspNetCore.Mvc;

namespace EPMS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalScheduleController : ControllerBase
    {
        private readonly IPersonalScheduleService _service;
        public PersonalScheduleController(IPersonalScheduleService service)
        {
            _service = service;
        }

        /// <summary>
        /// 添加个人日程
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(AddPersonalScheduleDto model)
        {
            var result = await _service.CreateAsync(model);
            return Ok(result);
        }

        /// <summary>
        /// 编辑个人日程
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> OutStock(EditPersonalScheduleDto model, int id)
        {
            var result = await _service.EditAsync(model,id);
            return Ok(result);
        }

        /// <summary>
        /// 分页查询个人日程
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("QueryPagin")]
        public async Task<IActionResult> QueryPaginAsync(SelectPersonalScheduleDto model)
        {

            var result = await _service.QueryAsync(model);

            return Ok(result);
        }

        /// <summary>
        /// 删除个人日程
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