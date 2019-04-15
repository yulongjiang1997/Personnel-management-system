using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Model.Dto.Products
{
    public class EditProductDto
    {
        public DateTime LastUpTime { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 产品编号
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public double Price { get; set; }
    }
}
