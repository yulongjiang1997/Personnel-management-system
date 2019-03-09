using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Model.Dto
{
    public class ReturnPagin<T>
    {
        public T Items { get; set; }

        public int Count { get; set; }

        public int Number { get; set; }

        public int Page { get; set; }
    }
}
