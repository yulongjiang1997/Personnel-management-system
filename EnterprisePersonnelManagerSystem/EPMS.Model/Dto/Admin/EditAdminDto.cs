using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Model.Dto.Admin
{
    public class EditAdminDto
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public DateTime LastUpTime { get; set; }
    }
}
