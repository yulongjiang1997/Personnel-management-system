using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Model.Dto.Positions
{
    public class SelectPositionDto:SelectBaseDto
    {
        public int? DepartmentId { get; set; }
    }
}
