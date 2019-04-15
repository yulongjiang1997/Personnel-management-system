using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Model.Dto.Salarys
{
    public class ReturnSalaryDto
    {

        public int Id { get; set; }

        /// <summary>
        /// 基本薪资
        /// </summary>
        public double BasicSalary { get; set; }

        /// <summary>
        /// 交通补贴
        /// </summary>
        public double TransportationSubsidy { get; set; }

        /// <summary>
        /// 餐费补贴
        /// </summary>
        public double MealSubsidy { get; set; }

        /// <summary>
        /// 其他补贴
        /// </summary>
        public double OtherSubsidies { get; set; }

        /// <summary>
        /// 奖励
        /// </summary>
        public double Reward { get; set; }

        /// <summary>
        /// 惩罚
        /// </summary>
        public double Deduction { get; set; }


        public string StaffInfoName { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
