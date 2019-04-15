using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Model.Dto.Positions
{
    public class ReturnPositionDto
    {
        public string Name { get; set; }

        public string DepartmentName { get; set; }

        public int Id { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime LastUpTime { get; set; }
    }
}
