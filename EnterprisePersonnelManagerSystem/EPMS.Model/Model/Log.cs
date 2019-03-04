using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EPMS.Model.Model
{
    public class Log : BaseModel
    {
        /// <summary>
        /// 管理员ID
        /// </summary>
        public string AdminId { get; set; }

        [ForeignKey("AdminId")]
        public Admin Admin { get; set; }

        /// <summary>
        /// 操作事件
        /// </summary>
        public string OperationEvent { get; set; }

        /// <summary>
        /// 数据列表
        /// </summary>
        public string OperationData { get; set; }
    }
}
