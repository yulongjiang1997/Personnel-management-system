using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPMS.Model.Model
{
    /// <summary>
    /// 职位
    /// </summary>
    public class Position : BaseModel
    {
        [StringLength(50)]
        public string Name { get; set; }

        public int DepartmentId { get; set; }

        /// <summary>
        /// 关联部门ID外键
        /// </summary>
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}