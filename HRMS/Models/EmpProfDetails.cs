using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Models
{
    public partial class EmpProfDetails
    {
        public int ProfId { get; set; }
        public int EmpProfId { get; set; }
        public string PrvOrganizationName { get; set; }
        public string PrvDesignation { get; set; }
        public string PrvJobLocation { get; set; }
        public string PrvWorkDuration { get; set; }
        public string PrvManagerNo { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
    }
}
