using EPMS.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Model.Dto.Stocks
{
    public class EditStockDto
    {
        public DateTime LastUpDateTime { get; set; }

        public int PrductId { get; set; }

        public int Number { get; set; }

        public InAndOutStockType InOrOut { get; set; }
    }
}
