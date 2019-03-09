using EPMS.Model.Dto;
using EPMS.Model.Dto.Positions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EPMS.Service.Services.PositionService
{
    public interface IPositionService
    {
        /// <summary>
        /// 添加职位
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnData<bool>> CreateAsync(AddPositionDto model);

        /// <summary>
        /// 删除职位
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// 编辑职位
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnData<bool>> EditAsync(int id, EditPositionDto model);

        /// <summary>
        /// 分页查询职位
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnPagin<List<ReturnPositionDto>>> QueryPaginAsync(SelectPositionDto model);

        /// <summary>
        /// 根据部门ID获得职位
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<ReturnPositionDto>> GetPositionByDepartmentId(int id);
    }
}
