using FluentValidation;
using Task_Managment.DTOs.Project.Create;

namespace Task_Managment.Validations.Project
{
    public class ProjectCreateDTOValidator : AbstractValidator<ProjectCreateDTO>
    {
        public ProjectCreateDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Project name is required.")
                .MaximumLength(100).WithMessage("Project name cannot exceed 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

            RuleFor(x => x.StartDate)
                .LessThan(x => x.EndDate)
                .WithMessage("Start date must be before end date.");
        }
    }
}
