using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Models
{
    [Keyless]
    public class EmpJoining
    {
        public EmpDetails EmpDtl { get; set; }
        public EmpBankDetails EmpBankDtl { get; set; }
        public EmpEdu_ProfDetails EmpEduPrfDtl { get; set; }
        public List<SelectListItem> GenderList { get; set; }
        public List<SelectListItem> MaritalList { get; set; }
        public List<SelectListItem> BloodGroupList { get; set; }
        public List<EmpEdu_ProfDetails> EmpEduProfDtl { get; set; }

    }
}
