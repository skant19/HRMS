using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#nullable disable

namespace HRMS.Models
{
    public partial class Application
    {
        public int Applicationid { get; set; }
        public string Recruitmentid { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Resume { get; set; }
        
        
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }


    }
}
