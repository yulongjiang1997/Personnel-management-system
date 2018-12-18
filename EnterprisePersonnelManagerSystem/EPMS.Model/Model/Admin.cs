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
    public class Admin: BaseModel
    {
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(255)]
        public string PassWord { get; set; }

        public virtual ICollection<LoginInfo> LoginInfos { get; set; }
    }
}
