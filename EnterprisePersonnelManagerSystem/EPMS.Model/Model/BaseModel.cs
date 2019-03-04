using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EPMS.Model.Model
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        public DateTime CreateTime { get; set; }
        [StringLength(30)]
        public DateTime? LastUpTime { get; set; }

        public BaseModel()
        {
            CreateTime = DateTime.Now;
            LastUpTime = null;
        }
    }
}
