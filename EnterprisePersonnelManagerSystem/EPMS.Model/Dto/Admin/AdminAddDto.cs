using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Model.Dto.Admin
{
    public class AdminAddDto
    {
        public string Account { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
