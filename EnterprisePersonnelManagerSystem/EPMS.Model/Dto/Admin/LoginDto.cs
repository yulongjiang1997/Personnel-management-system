using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Model.Dto.Admin
{
    public class LoginDto
    {
        public string NameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
