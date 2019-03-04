using EPMS.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EPMS.Model.Model
{
    public class InAndOutStockDetailed:BaseModel
    {

        /// <summary>
        /// 库存ID
        /// </summary>
        public int StockId { get; set; }

        [ForeignKey("StockId")]
        public Stock Stock { get; set; }

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
