using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Model.Dto.Attendances
{
    public class SelectAttendanceDto:SelectBaseDto
    {

        /// <summary>
        /// 是否迟到
        /// </summary>
        public bool? IsLate { get; set; }

        /// <summary>
        /// 是否早退
        /// </summary>
        public bool? IsLeaveEarly { get; set; }

        public int? StaffInfoId { get; set; }
    }
}
