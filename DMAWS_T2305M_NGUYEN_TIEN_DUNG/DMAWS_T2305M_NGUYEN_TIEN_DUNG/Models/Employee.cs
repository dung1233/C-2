using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DMAWS_T2305M_NGUYEN_TIEN_DUNG.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string EmployeeName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Employee), nameof(ValidateEmployeeDOB))]
        public DateTime EmployeeDOB { get; set; }

        [Required]
        public string EmployeeDepartment { get; set; }

        public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; }

        public static ValidationResult ValidateEmployeeDOB(DateTime dob, ValidationContext context)
        {
            if (dob > DateTime.Now.AddYears(-16))
            {
                return new ValidationResult("Employee must be at least 16 years old.");
            }
            return ValidationResult.Success;
        }
    }
}
