using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Model.Dto.Positions
{
    public class EditPositionDto
    {
        public string Name { get; set; }

        public int DepartmentId { get; set; }
        public DateTime LastUpTime { get; set; }
    }
}
