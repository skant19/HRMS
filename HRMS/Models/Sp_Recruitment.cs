using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Models
{
    [Keyless]
    public class Sp_Recruitment
    {
        public int PositionId { get; set; }
        public string Position { get; set; }
        public string Technology { get; set; }
        public int NoofResources { get; set; }
        public string Remark { get; set; }
        public string Experience { get; set; }
    }
}
