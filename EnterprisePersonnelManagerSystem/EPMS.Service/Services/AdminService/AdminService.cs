using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using EF;
using EPMS.Model.Dto.Admin;
using EPMS.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace EPMS.Service.Services.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly EPMSContext _context;
        public AdminService(EPMSContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ReturnLoginDto> Login(LoginDto model)
        {
            var token = MD5Encrypt32(model.NameOrEmail + model.Password + DateTime.Now.ToString());
            var admin = await _context.Admins.FirstOrDefaultAsync(i =>
            (i.Email == model.NameOrEmail
            || i.Name == model.NameOrEmail)
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
                        Admin = admin,
                        CreateTime = DateTime.Now,
                        OutTime = DateTime.Now.AddMinutes(30),
                        Token = token
                    });
                }
                await _context.SaveChangesAsync();
            }
            return admin != null ? new ReturnLoginDto { Name = admin.Name, Token = token } : null;

        }

        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Create(AdminAddOrEditDto model)
        {
            if (await CheckAdminEmail(model.Email))
            {
                _context.Admins.Add(
                    new Admin
                    {
                        Email = model.Email,
                        Name = model.Name,
                        PassWord = MD5Encrypt32(model.Password)
                    }
                    );
            }
            return await _context.SaveChangesAsync() > 0;

        }

        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(string id)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(i => i.Id == id);
            if (admin != null)
            {
                _context.Admins.Remove(admin);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 编辑管理员信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<bool> Edit(AdminAddOrEditDto model, string id)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(i => i.Id == id);
            if (admin != null)
            {
                if (await CheckAdminEmail(model.Email, id))
                {
                    admin.Email = model.Email;
                    admin.LastUpTime = DateTime.Now;
                    admin.Name = model.Name;
                    admin.PassWord = MD5Encrypt32(model.Password);
                }
            }

            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 查询管理员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task<List<ReturnAdminDto>> Query(SelectAdminDto model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据Id查询管理员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task<ReturnAdminDto> QueryById(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 检查Email 是否重复
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private async Task<bool> CheckAdminEmail(string email, string id = null)
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
        public async Task<bool> CheckTokenTimeOut(string email, string token)
        {
            var result = await _context.LoginInfos.FirstOrDefaultAsync(i => i.Admin.Email == email && i.OutTime > DateTime.Now && i.Token == token);
            return result != null;
        }

    }
}
