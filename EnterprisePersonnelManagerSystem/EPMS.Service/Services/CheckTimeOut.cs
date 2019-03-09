using EPMS.Model.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EPMS.Service.Services
{
    public class CheckTimeOut
    {
        public static async Task<ReturnData<bool>> Check(DateTime modelTime, DateTime dbTime)
        {
            var result = new ReturnData<bool>();
            if (modelTime != dbTime)
            {
                result.Message = "操作超时，请刷新页面重试";
                result.Result = result.Success = false;
            }
            return result;
        }
    }
}
