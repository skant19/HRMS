using System;
using System.Collections.Generic;

#nullable disable

namespace HRMS.Models
{
   
        public partial class JobRequest
    {
        public int Id { get; set; }
        public string RecruitmentId { get; set; }
        public string Position { get; set; }
        public string Technology { get; set; }
        public int NoofResource { get; set; }
        public string Remark { get; set; }
        public string Experience { get; set; }
        public string Hrremark { get; set; }
    }
}
