using EPMS.Model.Dto;
using EPMS.Model.Dto.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EPMS.Service.Services.ProductService
{
    public interface IProductService
    {
        /// <summary>
        /// 添加商品信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnData<bool>> CreateAsync(AddProductDto model);

        /// <summary>
        /// 删除商品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// 编辑商品信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnData<bool>> EditAsync(int id, EditProductDto model);

        /// <summary>
        /// 分页查询商品信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnPagin<List<ReturnProductDto>>> QueryPaginAsync(SelectProductDto model);
    }
}
