using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EPMS.Model.Model
{
    /// <summary>
    /// 员工信息
    /// </summary>
    public class StaffInfo:BaseModel
    {
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(14)]
        public string Phone { get; set; }
        [StringLength(30)]
        public DateTime EntryTime { get; set; }
        [StringLength(30)]
        public DateTime? ResignationTime { get; set; }
        [StringLength(50)]
        public string Email { get; set; }

        [ForeignKey("PositionId")]
        public Position Position { get; set; }

        /// <summary>
        /// 薪资导航
        /// </summary>
        public virtual ICollection<Salary> Salarys { get; set; }

        /// <summary>
        /// 考勤导航
        /// </summary>
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
