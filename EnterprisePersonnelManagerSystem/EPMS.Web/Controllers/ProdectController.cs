using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPMS.Model.Dto.Products;
using EPMS.Model.Dto.Stocks;
using EPMS.Service.Services.ProductService;
using EPMS.Service.Services.StockService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPMS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }

        /// <summary>
        /// 添加商品信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(AddProductDto model)
        {
            var result = await _service.CreateAsync(model);
            return Ok(result);
        }

        /// <summary>
        /// 编辑商品信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> OutStock(EditProductDto model, int id)
        {
            var result = await _service.EditAsync(id, model);
            return Ok(result);
        }

        /// <summary>
        /// 分页查询商品信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("QueryPagin")]
        public async Task<IActionResult> QueryPaginAsync(SelectProductDto model)
        {

            var result = await _service.QueryPaginAsync(model);

            return Ok(result);
        }

        /// <summary>
        /// 删除商品信息
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