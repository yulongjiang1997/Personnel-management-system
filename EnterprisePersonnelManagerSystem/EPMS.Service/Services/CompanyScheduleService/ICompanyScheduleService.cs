using EPMS.Model.Dto;
using EPMS.Model.Dto.CompanySchedules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EPMS.Service.Services.CompanyScheduleService
{
    public interface ICompanyScheduleService
    {
        /// <summary>
        /// 添加公司日志
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnData<bool>> CreateAsync(AddCompanyScheduleDto model);

        /// <summary>
        /// 删除公司日志
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// 编辑公司日志
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ReturnData<bool>> EditAsync(EditCompanyScheduleDto model, int id);

        /// <summary>
        /// 分页查询公司日志
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnPagin<List<ReturnCompanyScheduleDto>>> QueryAsync(SelectCompanyScheduleDto model);
    }
}
