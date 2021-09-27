using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Models
{
    public partial class EmpDetails
    {
        [Key]
        public int EmpProfId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Doj { get; set; }
        public string Father_SpouseName { get; set; }
        public string DesignationName { get; set; }
        public DateTime? Dob { get; set; }
        
        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }
        
        public string MaritialStatus { get; set; }
        public string BloodGroup { get; set; }
        public string TelephoneNo { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string AltEmail { get; set; }
        public string AadhaarNo { get; set; }
        public string PanCardNo { get; set; }
        public string EmgContactName { get; set; }
        public string RelationWithEmp { get; set; }
        public string EmgContactNo { get; set; }
        public string C_AddL1 { get; set; }
        public string C_AddL2 { get; set; }
        public string C_City { get; set; }
        public string C_State { get; set; }
        public string C_Zip { get; set; }
        public string C_Country { get; set; }
        public string P_AddL1 { get; set; }
        public string P_AddL2 { get; set; }
        public string P_City { get; set; }
        public string P_State { get; set; }
        public string P_Zip { get; set; }
        public string P_Country { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
    }
}
