using EPMS.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Model.Dto.Stocks
{
    public class ReturnStockAccessDto
    {
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 库存商品名称
        /// </summary>
        public string StockProductName { get; set; }

        /// <summary>
        /// 进出库类型
        /// </summary>
        public InAndOutStockType InAndOutStockType { get; set; }


        /// <summary>
        /// 操作数量
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 剩余库存
        /// </summary>
        public int SurplusStock { get; set; }
    }
}
