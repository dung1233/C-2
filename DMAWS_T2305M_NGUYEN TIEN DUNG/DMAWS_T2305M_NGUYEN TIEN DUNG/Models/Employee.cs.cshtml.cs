using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
namespace DMAWS_T2305M_NGUYEN_TIEN_DUNG.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public DateTime EmployeeDOB { get; set; }

        public string EmployeeDepartment { get; set; }

        public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; } // Quan h? v?i ProjectEmployee
    }
}
