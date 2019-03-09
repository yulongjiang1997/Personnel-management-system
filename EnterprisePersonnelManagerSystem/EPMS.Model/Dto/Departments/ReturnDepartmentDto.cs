using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Model.Dto.Departments
{
    public class ReturnDepartmentDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastUpTime { get; set; }
    }
}
