using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Model.Dto.Products
{
    public class SelectProductDto:SelectBaseDto
    {
        public string Name { get; set; }
        public double? BeginPrice { get; set; }
        public double? EndPrice { get; set; }
        public string ProductNumber { get; set; }
    }
}
