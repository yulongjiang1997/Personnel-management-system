using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Model
{
    public class ControllerReturnData<T>
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public T Obj{get;set;}
        public ControllerReturnData()
        {
            Success = true;
        }
    }
}
