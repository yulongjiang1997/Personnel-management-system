using EPMS.Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EPMS.Model.Model
{
    /// <summary>
    /// 管理员
    /// 
    /// </summary>
    public class Admin
    {
        public Admin()
        {
            CreateTime = DateTime.UtcNow;
            LastUpTime = null;
        }

        [Key]
        public string Id { get; set; }
        [StringLength(30)]
        public DateTime CreateTime { get; set; }
        [StringLength(30)]
        public DateTime? LastUpTime { get; set; }

        [StringLength(30)]
        public string Account { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(255)]
        public string PassWord { get; set; }
    }
}
