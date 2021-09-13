using System;
using System.Collections.Generic;

#nullable disable

namespace HRMS.Models
{
    public partial class Department
    {
        public int DepartmentId { get; set; }
        public int? CompanyId { get; set; }
        public string DepartmentName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
