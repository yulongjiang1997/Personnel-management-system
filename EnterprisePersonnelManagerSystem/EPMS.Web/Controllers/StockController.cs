using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPMS.Model.Dto.Stocks;
using EPMS.Service.Services.StockService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPMS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _service;
        public StockController(IStockService service)
        {
            _service = service;
        }

        /// <summary>
        /// 入库
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(AddStockDto model)
        {
            var result = await _service.CreateAsync(model);
            return Ok(result);
        }

        /// <summary>
        /// 出入库
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("InAndOut")]
        public async Task<IActionResult> InAndOut(EditStockDto model, int id)
        {
            var result = await _service.EditAsync(id, model);
            return Ok(result);
        }

        /// <summary>
        /// 分页查询库存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("QueryPagin")]
        public async Task<IActionResult> QueryPaginAsync(SelectStockDto model)
        {

            var result = await _service.QueryPaginStockAsync(model);

            return Ok(result);
        }

        /// <summary>
        /// 分页查询进出库明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("QueryInAndOutRecordPagin")]
        public async Task<IActionResult> QueryPaginStockRecordAsync(SelectStockAccessDto model)
        {

            var result = await _service.QueryPaginStockRecordAsync(model);

            return Ok(result);
        }

        /// <summary>
        /// 删除库存
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