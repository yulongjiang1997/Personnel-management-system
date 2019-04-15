using System.Threading.Tasks;
using EPMS.Model.Dto.Positions;
using EPMS.Service.Services.PositionService;
using Microsoft.AspNetCore.Mvc;

namespace EPMS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _service;
        public PositionController(IPositionService service)
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
        public async Task<IActionResult> Create(AddPositionDto model)
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
        public async Task<IActionResult> OutStock(EditPositionDto model, int id)
        {
            var result = await _service.EditAsync(id, model);
            return Ok(result);
        }

        /// <summary>
        /// 分页查询职位信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("QueryPagin")]
        public async Task<IActionResult> QueryPaginAsync(SelectPositionDto model)
        {

            var result = await _service.QueryPaginAsync(model);

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