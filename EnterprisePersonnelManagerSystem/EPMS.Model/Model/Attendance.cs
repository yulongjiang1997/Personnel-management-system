using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EPMS.Model.Model
{
    /// <summary>
    /// 考勤明细
    /// </summary>
    public class Attendance : BaseModel
    {
        /// <summary>
        /// 上班时间
        /// </summary>
        [StringLength(30)]
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
        [StringLength(30)]
        public DateTime? OffworkTime { get; set; }

        public int StaffInfoId { get; set; }
        /// <summary>
        /// 关联员工ID外键
        /// </summary>
        [ForeignKey("StaffInfoId")]
        public StaffInfo StaffInfo { get; set; }
    }
}
