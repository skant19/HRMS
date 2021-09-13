using System;
using System.Collections.Generic;

#nullable disable

namespace HRMS.Models
{
    public partial class Role
    {
        public int RoleId { get; set; }
        public int DesignationId { get; set; }
        public string RoleName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
