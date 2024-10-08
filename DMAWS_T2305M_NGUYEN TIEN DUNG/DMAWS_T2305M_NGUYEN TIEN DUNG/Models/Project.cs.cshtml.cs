using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
namespace DMAWS_T2305M_NGUYEN_TIEN_DUNG.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public DateTime ProjectStartDate { get; set; }

        public DateTime? ProjectEndDate { get; set; } // Cho phép null

        public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; } // Quan h? v?i ProjectEmployee
    }
}
