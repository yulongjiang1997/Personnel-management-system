using EPMS.Model.Dto;
using EPMS.Model.Dto.PersonalSchedules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EPMS.Service.Services.PersonalScheduleService
{
    public interface IPersonalScheduleService
    {
        /// <summary>
        /// 添加个人日程
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnData<bool>> CreateAsync(AddPersonalScheduleDto model);

        /// <summary>
        /// 删除个人日程
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// 编辑个人日程
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ReturnData<bool>> EditAsync(EditPersonalScheduleDto model, int id);

        /// <summary>
        /// 分页查询个人日程
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnPagin<List<ReturnPersonalScheduleDto>>> QueryAsync(SelectPersonalScheduleDto  model);
    }
}
