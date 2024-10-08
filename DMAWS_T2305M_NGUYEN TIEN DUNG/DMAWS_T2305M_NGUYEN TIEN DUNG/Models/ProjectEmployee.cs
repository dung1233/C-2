using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
namespace DMAWS_T2305M_NGUYEN_TIEN_DUNG.Models
{
    public class ProjectEmployee
    {
        public int EmployeeId { get; set; } // Kh�a ngo?i t?i Employee

        public int ProjectId { get; set; } // Kh�a ngo?i t?i Project

        public string Tasks { get; set; } // Nhi?m v? trong d? �n

        public virtual Employee Employees { get; set; } // Quan h? v?i Employee

        public virtual Project Projects { get; set; } // Quan h? v?i Project
    }
}
