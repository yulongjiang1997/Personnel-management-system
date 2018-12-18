using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EPMS.Model.Model
{
    /// <summary>
    /// 考勤
    /// 
    /// </summary>
    public class Attendance:BaseModel
    {
        [StringLength(30)]
        public DateTime AttendanceTime { get; set; }
        [StringLength(30)]
        public DateTime WorkingTime { get; set; }
        [StringLength(30)]
        public DateTime? OffworkTime { get; set; }

        /// <summary>
        /// 关联员工ID外键
        /// </summary>
        [ForeignKey("StaffInfoId")]
        public StaffInfo StaffInfo { get; set; }
    }
}
