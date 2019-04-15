using EPMS.Model.Dto;
using EPMS.Model.Dto.Stocks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EPMS.Service.Services.StockService
{
    public interface IStockService
    {
        /// <summary>
        /// 入库
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnData<bool>> CreateAsync(AddStockDto model);

        /// <summary>
        /// 删除库存
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// 出库
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnData<bool>> EditAsync(int id, EditStockDto model);

        /// <summary>
        /// 添加库存记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnData<bool>> CreateStockAccessAsync(AddStockAccessDto model);

        /// <summary>
        /// 分页查询库存明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnPagin<List<ReturnStockAccessDto>>> QueryPaginStockRecordAsync(SelectStockAccessDto model);

        /// <summary>
        /// 分页查询库存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnPagin<List<ReturnStockDto>>> QueryPaginStockAsync(SelectStockDto model);
    }
}
