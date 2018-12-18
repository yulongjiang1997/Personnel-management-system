using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EPMS.Model.Model
{
    /// <summary>
    /// 考勤时间设置管理
    /// </summary>
    public class AttendanceTimeSet : BaseModel
    {
        [StringLength(30)]
        public DateTime WorkingTime { get; set; }
        [StringLength(30)]
        public DateTime OffworkTime { get; set; }
    }
}
