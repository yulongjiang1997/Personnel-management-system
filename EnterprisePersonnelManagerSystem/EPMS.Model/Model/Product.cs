using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EPMS.Model.Model
{
    public class Product:BaseModel
    {
        [StringLength(20)]
        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 产品编号
        /// </summary>
        public string Number { get; set; }

        [StringLength(7)]
        /// <summary>
        /// 价格
        /// </summary>
        public double Price { get; set; }
    }
}
