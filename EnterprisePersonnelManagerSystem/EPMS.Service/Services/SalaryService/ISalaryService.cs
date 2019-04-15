using EPMS.Model.Dto;
using EPMS.Model.Dto.Salarys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EPMS.Service.Services.SalaryService
{
    public interface ISalaryService
    {
        /// <summary>
        /// 添加工资条
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnData<bool>> CreateAsync(AddSalaryDto model);

        /// <summary>
        /// 删除工资条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// 分页查询工资条
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnPagin<List<ReturnSalaryDto>>> QueryPaginAsync(SelectSalaryDto model);
    }
}
