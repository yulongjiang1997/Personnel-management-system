using EPMS.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Model.Dto.Stocks
{
    public class AddStockAccessDto
    {
        /// <summary>
        /// 库存ID
        /// </summary>
        public int StockId { get; set; }

        /// <summary>
        /// 进出库类型
        /// </summary>
        public InAndOutStockType InAndOutStockType { get; set; }


        /// <summary>
        /// 操作数量
        /// </summary>
        public int Number { get; set; }
    }
}
