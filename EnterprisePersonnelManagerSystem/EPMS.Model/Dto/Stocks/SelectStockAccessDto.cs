using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Model.Dto.Stocks
{
    public class SelectStockAccessDto:SelectBaseDto
    {
        public int? StockId { get; set; }
    }
}
