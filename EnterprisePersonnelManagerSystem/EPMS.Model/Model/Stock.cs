using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EPMS.Model.Model
{
    public class Stock : BaseModel
    {
        public int PrductId { get; set; }

        [ForeignKey("PrductId")]
        public Product Product { get; set; }


        public int SurplusStock { get; set; }
    }
}
