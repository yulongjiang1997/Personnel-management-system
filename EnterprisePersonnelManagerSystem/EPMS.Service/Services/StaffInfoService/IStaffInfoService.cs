using EPMS.Model.Dto;
using EPMS.Model.Dto.Staffinfos;
using EPMS.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EPMS.Service.Services.StaffInfoService
{
    public interface IStaffInfoService
    {
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnData<bool>> CreateAsync(AddStaffinfoDto model);

        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// 编辑员工
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnData<bool>> EditAsync(int id, EditStaffinfoDto model);

        /// <summary>
        /// 分页查询员工
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnPagin<List<ReturnStaffinfoDto>>> QueryPaginAsync(SelectStaffinfoDto model);
    }
}
