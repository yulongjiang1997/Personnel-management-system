using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EPMS.Model.Model
{
    public class PersonalSchedule : BaseModel
    {
        /// <summary>
        /// 员工ID
        /// </summary>
        public int StaffId { get; set; }

        [ForeignKey("StaffId")]
        public StaffInfo StaffInfo { get; set; }

        /// <summary>
        /// 日程名称
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// 日程详情
        /// </summary>
        public string EventDetails { get; set; }

        /// <summary>
        /// 日程时间
        /// </summary>
        public DateTime ScheduleTime { get; set; }
    }
}
