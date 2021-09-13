using System;
using System.Collections.Generic;

#nullable disable

namespace HRMS.Models
{
    public partial class ExperienceTable
    {
        public int Id { get; set; }
        public string Experience { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
    }
}
