using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DMAWS_T2305M_NGUYEN_TIEN_DUNG.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string ProjectName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ProjectStartDate { get; set; }

        [DataType(DataType.Date)]
        [CustomValidation(typeof(Project), nameof(ValidateProjectEndDate))]
        public DateTime? ProjectEndDate { get; set; }

        public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; }

        public static ValidationResult ValidateProjectEndDate(DateTime? endDate, ValidationContext context)
        {
            var project = (Project)context.ObjectInstance;
            if (endDate.HasValue && endDate.Value < project.ProjectStartDate)
            {
                return new ValidationResult("ProjectEndDate must be after ProjectStartDate.");
            }
            return ValidationResult.Success;
        }
    }
}
