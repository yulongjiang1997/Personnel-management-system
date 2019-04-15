using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Model.Dto.Attendances
{
    public class ReturnAttendanceDto
    {
        /// <summary>
        /// 上班时间
        /// </summary>
        public DateTime WorkingTime { get; set; }

        /// <summary>
        /// 是否迟到
        /// </summary>
        public bool IsLate { get; set; }

        /// <summary>
        /// 是否早退
        /// </summary>
        public bool IsLeaveEarly { get; set; }

        /// <summary>
        /// 下班时间
        /// </summary>
        public DateTime? OffworkTime { get; set; }

        public string StaffInfoName { get; set; }

        public int Id { get; set; }
    }
}
