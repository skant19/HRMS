using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Models
{
    public partial class EmpEduDetails
    {
        [Key]
        public int EduId { get; set; }
        public int EmpProfId { get; set; }
        public string Degree { get; set; }
        public string University { get; set; }
        public DateTime? DFrom { get; set; }
        public DateTime? DTo { get; set; }
        public string PercentageGrade { get; set; }
        public string Specification { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
    }
}
