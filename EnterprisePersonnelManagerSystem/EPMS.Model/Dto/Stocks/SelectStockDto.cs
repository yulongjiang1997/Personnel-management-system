using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Model.Dto.Stocks
{
    public class SelectStockDto:SelectBaseDto
    {
        public int? ProductId { get; set; }
    }
}
