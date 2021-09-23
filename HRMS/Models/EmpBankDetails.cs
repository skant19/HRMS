using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Models
{
    public partial class EmpBankDetails
    {
        [Key]
        public int BankId { get; set; }
        public int EmpProfId { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public string ConfAccountNo { get; set; }
        public string IfscCode { get; set; }
        public string UanNo { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
    }
}
