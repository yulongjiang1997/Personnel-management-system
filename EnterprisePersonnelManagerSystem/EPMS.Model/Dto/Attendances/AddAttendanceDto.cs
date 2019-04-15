using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Model.Dto.Attendances
{
    public class AddAttendanceDto
    {
        /// <summary>
        /// 上班时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        public int StaffInfoId { get; set; }
    }
}
