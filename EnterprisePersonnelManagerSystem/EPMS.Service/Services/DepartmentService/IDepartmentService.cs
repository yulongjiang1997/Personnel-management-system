using EPMS.Model.Dto;
using EPMS.Model.Dto.Departments;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EPMS.Service.Services.DepartmentService
{
    public interface IDepartmentService 
    {
        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnData<bool>> CreateAsync(AddDepartmentDto model);

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// 编辑部门
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> EditAsync(EditDepartmentDto model, int id);

        /// <summary>
        /// 分页查询部门
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<List<ReturnDepartmentDto>> QueryAsync(SelectDeparmentDto model);
    }
}
