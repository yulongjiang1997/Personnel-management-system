using EPMS.Model.Enums;
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
    public class StaffInfo : BaseModel
    {
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(11)]
        public string Phone { get; set; }
        [StringLength(30)]
        public DateTime EntryTime { get; set; }
        [StringLength(30)]
        public DateTime? ResignationTime { get; set; }
        [StringLength(50)]
        public string Email { get; set; }

        public int PositionId { get; set; }
        [ForeignKey("PositionId")]
        public Position Position { get; set; }

        public WorkingStatus WorkingStatus { get; set; }
    }
}
