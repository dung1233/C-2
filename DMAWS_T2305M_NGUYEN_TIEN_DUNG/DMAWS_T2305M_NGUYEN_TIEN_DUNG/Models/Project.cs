using System.ComponentModel.DataAnnotations;

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

    // Cho phép ProjectEmployees nullable
    public virtual ICollection<ProjectEmployee>? ProjectEmployees { get; set; } = new List<ProjectEmployee>();

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
