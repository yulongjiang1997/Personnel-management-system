using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Model.Dto.Admin
{
    public class ReturnLoginDto
    {
        public string UserId { get; set; }
        public string Token { get; set; }

        public string UserName { get; set; }

        public bool IsSuperAdmin { get; set; }
    }
}
