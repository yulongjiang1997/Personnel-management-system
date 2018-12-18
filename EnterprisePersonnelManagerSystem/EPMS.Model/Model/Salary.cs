using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EPMS.Model.Model
{
    /// <summary>
    /// 薪资
    /// </summary>
    public class Salary:BaseModel
    {
        [StringLength(20)]
        public double BasicSalary { get; set; }
        [StringLength(20)]
        public double TransportationSubsidy { get; set; }
        [StringLength(20)]
        public double MealSubsidy { get; set; }
        [StringLength(20)]
        public double OtherSubsidies { get; set; }
        [StringLength(20)]
        public double AttendanceRewardAndPunishment { get; set; }

        [ForeignKey("StaffInfoId")]
        public StaffInfo StaffInfo { get; set; }
    }
}
