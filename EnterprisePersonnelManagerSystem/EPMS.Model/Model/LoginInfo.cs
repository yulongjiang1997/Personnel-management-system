using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EPMS.Model.Model
{
    public class LoginInfo : BaseModel
    {
        public string AdminId { get; set; }
        [ForeignKey("AdminId")]
        public Admin Admin { get; set; }
        public string Token { get; set; }
        public DateTime OutTime { get; set; }
    }
}
