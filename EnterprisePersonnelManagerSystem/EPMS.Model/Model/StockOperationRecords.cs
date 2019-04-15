using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EPMS.Model.Model
{
    public class StockOperationRecords : BaseModel
    {
        public int StockId { get; set; }

        [ForeignKey("StockId")]
        public Stock Stock { get; set; }

        public int Number { get; set; }

        public int InOrOut { get; set; }

        public int SurplusStock { get; set; }
    }
}
