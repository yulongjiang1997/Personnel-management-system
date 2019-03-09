using EPMS.Model.Dto.Admin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EPMS.Service.Services.AdminService
{
    public interface IAdminService
    {
        /// <summary>
        /// 检查Token
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        Task<bool> CheckTokenTimeOutAsync(string email,string token);

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnLoginDto> LoginAsync(LoginDto model);

        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> CreateAsync(AdminAddDto model);

        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(string id);

        /// <summary>
        /// 编辑管理员
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> EditAsync(EditAdminDto model, string id);

        /// <summary>
        /// 分页查询管理员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<List<ReturnAdminDto>> QueryAsync(SelectAdminDto model);

        /// <summary>
        /// 根据ID查询管理员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ReturnAdminDto> QueryByIdAsync(string id);
    }
}
