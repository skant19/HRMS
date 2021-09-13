using System;
using System.Collections.Generic;

#nullable disable

namespace HRMS.Models
{
    public partial class UserType
    {
        public int UserId { get; set; }
        public string UserType1 { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
