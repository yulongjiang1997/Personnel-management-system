using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Model.Dto.Admin
{
    public class LoginDto
    {
        public string AccountOrEmail { get; set; }
        public string Password { get; set; }
    }
}
