using System;
using System.Collections.Generic;

#nullable disable

namespace HRMS.Models
{
    public partial class LogDetail
    {
        public int LogDetailId { get; set; }
        public int? UserId { get; set; }
        public DateTime? LoginDateTime { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
    }
}
