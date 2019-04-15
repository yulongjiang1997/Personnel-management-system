using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Model.Dto.Admin
{
    public class ReturnAdminDto
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Account { get; set; }

        public string Email { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastUpTime { get; set; }
    }
}
