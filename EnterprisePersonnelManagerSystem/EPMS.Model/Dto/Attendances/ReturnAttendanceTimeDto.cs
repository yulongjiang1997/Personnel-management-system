using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Model.Dto.Attendances
{
    public class ReturnAttendanceTimeDto
    {
        public int Id { get; set; }
        public string WorkingTime { get; set; }
        public string OffworkTime { get; set; }

        public DateTime LastUpDateTime { get; set; }
    }
}
