using System;
using System.Collections.Generic;

#nullable disable

namespace HRMS.Models
{
    public partial class Recruitment
    {
        public int PositionId { get; set; }
        public string Position { get; set; }
        public int? Experience { get; set; }
        public string Technology { get; set; }
        public int? NoofResources { get; set; }
        public string Remark { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
