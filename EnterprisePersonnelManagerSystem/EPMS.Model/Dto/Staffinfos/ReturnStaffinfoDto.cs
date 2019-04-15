using EPMS.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPMS.Model.Dto.Staffinfos
{
    public class ReturnStaffinfoDto
    {
        public DateTime LastUpTime { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime? ResignationTime { get; set; }
        public string Email { get; set; }

        public string PositionName { get; set; }

        public WorkingStatus WorkingStatus { get; set; }
    }
}
