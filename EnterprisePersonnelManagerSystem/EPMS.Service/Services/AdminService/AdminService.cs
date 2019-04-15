using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EPMSEF;
using EPMS.Model.Dto.Admin;
using EPMS.Model.Model;
using Microsoft.EntityFrameworkCore;
using EPMS.Model.Dto;

namespace EPMS.Service.Services.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly EPMSContext _context;
        private readonly IMapper _mapper;
        public AdminService(EPMSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ReturnData<ReturnLoginDto>> LoginAsync(LoginDto model)
        {
            var result = new ReturnData<ReturnLoginDto>();
            var token = MD5Encrypt32(model.AccountOrEmail + model.Password + DateTime.Now.ToString());
            var admin = await _context.Admins.FirstOrDefaultAsync(i => (i.Email == model.AccountOrEmail
                                                                      || i.Account == model.AccountOrEmail)
                                                                  && i.PassWord == MD5Encrypt32(model.Password));
            if (admin != null)
            {
                //如果登陆成功则更新token 然后把用户名和token 一起返回每次操作验证token有效性
                var loginInfo = await _context.LoginInfos.FirstOrDefaultAsync(i => i.Admin.Id == admin.Id);
                if (loginInfo != null)
                {
                    loginInfo.OutTime = DateTime.Now.AddMinutes(30);
                    loginInfo.LastUpTime = DateTime.Now;
                    loginInfo.Token = token;
                }
                else
                {
                    _context.LoginInfos.Add(new LoginInfo
                    {
                        AdminId = admin.Id,
                        CreateTime = DateTime.Now,
                        OutTime = DateTime.Now.AddMinutes(60),
                        Token = token
                    });
                }
                await _context.SaveChangesAsync();

                result.Result = new ReturnLoginDto { UserId = admin.Id, Token = token, UserName = admin.Name, IsSuperAdmin = admin.IsSuperAdmin };
                return result;
            }
            result.Result = null;
            return result;

        }

        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ReturnData<bool>> CreateAsync(AdminAddDto model)
        {
            var result = new ReturnData<bool>();
            if (await CheckAdminEmailAsync(model.Email))
            {
                _context.Admins.Add(
                    new Admin
                    {
                        Account = model.Account,
                        Id = Guid.NewGuid().ToString(),
                        Email = model.Email,
                        Name = model.Name,
                        PassWord = MD5Encrypt32(model.Password),
                    }
                    );
            }
            result.Result = await _context.SaveChangesAsync() > 0;
            return result;

        }

        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<ReturnData<bool>> DeleteAsync(string id)
        {
            var result = new ReturnData<bool>();
            var admin = await _context.Admins.FirstOrDefaultAsync(i => i.Id == id);
            if (admin != null)
            {
                _context.Admins.Remove(admin);
            }
            result.Result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        /// <summary>
        /// 编辑管理员信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<ReturnData<bool>> EditAsync(EditAdminDto model, string id)
        {
            var result = new ReturnData<bool>();
            var admin = await _context.Admins.FirstOrDefaultAsync(i => i.Id == id);
            if (admin != null)
            {
                if (await CheckAdminEmailAsync(model.Email, id))
                {
                    admin.Email = model.Email;
                    admin.LastUpTime = DateTime.Now;
                    admin.Name = model.Name;
                    admin.Account = model.Account;
                    if (!string.IsNullOrEmpty(model.Password))
                    {
                        admin.PassWord = MD5Encrypt32(model.Password);
                    }
                    // admin.PassWord = MD5Encrypt32(model.Password);
                }
            }

            result.Result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        /// <summary>
        /// 查询管理员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<List<ReturnAdminDto>> QueryAsync(SelectAdminDto model)
        {
            var result = new List<ReturnAdminDto>();

            var admin = _context.Admins.AsNoTracking();

            result = _mapper.Map<List<ReturnAdminDto>>(await admin.Pagin(model).ToListAsync());

            return result;
        }

        /// <summary>
        /// 根据Id查询管理员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ReturnAdminDto> QueryByIdAsync(string id)
        {
            var admin = _context.Admins.FirstOrDefaultAsync(i => i.Id == id);

            return _mapper.Map<ReturnAdminDto>(await admin); ;
        }

        /// <summary>
        /// 检查Email 是否重复
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private async Task<bool> CheckAdminEmailAsync(string email, string id = null)
        {
            Admin admin = null;
            if (!string.IsNullOrEmpty(id))
            {
                admin = await _context.Admins.FirstOrDefaultAsync(i => i.Email.Equals(email) && i.Id != id);
            }
            else
            {
                admin = await _context.Admins.FirstOrDefaultAsync(i => i.Email.Equals(email));

            }
            return admin != null ? false : true;
        }

        /// 32位MD5加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private static string MD5Encrypt32(string password)
        {
            string cl = password;
            string pwd = "";
            MD5 md5 = MD5.Create(); //实例化一个md5对像
                                    // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                pwd = pwd + s[i].ToString("X");
            }
            return pwd;
        }

        /// <summary>
        /// 检查Token是否在有效期
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public bool CheckTokenTimeOutAsync(string adminId, string token)
        {
            var result = _context.LoginInfos.FirstOrDefault(i => i.AdminId == adminId && i.OutTime > DateTime.Now && i.Token == token);
            return result != null;
        }

    }
}
