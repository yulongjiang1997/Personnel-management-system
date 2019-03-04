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
        /// <summary>
        /// 基本薪资
        /// </summary>
        [StringLength(7)]
        public double BasicSalary { get; set; }

        /// <summary>
        /// 交通补贴
        /// </summary>
        [StringLength(7)]
        public double TransportationSubsidy { get; set; }

        /// <summary>
        /// 餐费补贴
        /// </summary>
        [StringLength(7)]
        public double MealSubsidy { get; set; }

        /// <summary>
        /// 其他补贴
        /// </summary>
        [StringLength(7)]
        public double OtherSubsidies { get; set; }

        /// <summary>
        /// 奖励
        /// </summary>
        [StringLength(7)]
        public double Reward { get; set; }

        /// <summary>
        /// 惩罚
        /// </summary>
        [StringLength(7)]
        public double Deduction { get; set; }


        public int StaffInfoId { get; set; }

        [ForeignKey("StaffInfoId")]
        public StaffInfo StaffInfo { get; set; }
    }
}
