﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Model.Dto.CompanySchedules
{
    public class AddCompanyScheduleDto
    {
        /// <summary>
        /// 日程名称
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// 日程详情
        /// </summary>
        public string EventDetails { get; set; }

        /// <summary>
        /// 日程时间
        /// </summary>
        public DateTime ScheduleTime { get; set; }
    }
}