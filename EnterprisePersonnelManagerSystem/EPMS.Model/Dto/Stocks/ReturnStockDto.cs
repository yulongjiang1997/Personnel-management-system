using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Model.Dto.Stocks
{
    public class ReturnStockDto
    {
        public int Id { get; set; }
        public DateTime LastUpTime { get; set; }

        public string ProductName { get; set; }

        public int Number { get; set; }
    }
}
