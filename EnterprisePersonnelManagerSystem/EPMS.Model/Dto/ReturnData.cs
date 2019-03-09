using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Model.Dto
{
    public class ReturnData<T>
    {
        public string Message { get; set; }

        public bool Success { get; set; }

        public T Result { get; set; }

        public ReturnData()
        {
            Success = true;
        }
    }
}
