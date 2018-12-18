using EPMS.Service.Services.AdminService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPMS.Web.ActionFilter
{
    public class BaseService
    {
        private readonly IAdminService _service;
        public readonly BaseService _bs;
        public BaseService(IAdminService service, BaseService bs)
        {
            _service = service;
            _bs = bs;
        }

        public IAdminService GetAdminService()
        {
            return _bs.GetAdminService();
        }
    }
}
