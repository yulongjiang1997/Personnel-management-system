using EPMS.Model.Dto;
using EPMS.Model.Dto.Attendances;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EPMS.Service.Services.AttendanceService
{
    public interface IAttendanceService
    {

        /// <summary>
        /// 添加考勤记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnData<bool>> CreateAsync(AddAttendanceDto model);

        /// <summary>
        /// 分页查询考勤记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnPagin<List<ReturnAttendanceDto>>> QueryPaginAsync(SelectAttendanceDto model);

        /// <summary>
        /// 添加或修改考勤时间
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnData<bool>> CreateOrEditAttendanceTimeAsync(AddOrEditAttendanceTimeDto model);

        /// <summary>
        /// 获取当前考勤时间
        /// </summary>
        /// <returns></returns>
        Task<ReturnAttendanceTimeDto> GetAttendanceTime();
    }
}
