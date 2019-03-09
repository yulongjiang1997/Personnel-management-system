using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Model.Dto
{
    public class SelectBaseDto
    {
        public SelectBaseDto()
        {
            Page = 1;
            Number = 10;
        }
        public DateTime? BeginTime { get; set; }

        public DateTime? EndTime { get; set; }

        public int Page { get; set; }

        public int Number { get; set; }
    }
}
