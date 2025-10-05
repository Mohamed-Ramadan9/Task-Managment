using FluentValidation;
using Task_Managment.DTOs.Project.Update;

namespace Task_Managment.Validations.Project
{
    public class ProjectUpdateDTOValidator : AbstractValidator<ProjectUpdateDTO>
    {
        public ProjectUpdateDTOValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Project ID must be greater than zero.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Project name is required.")
                .MaximumLength(100).WithMessage("Project name cannot exceed 100 characters.");

            RuleFor(x => x.EndDate)
                .GreaterThan(x => x.StartDate)
                .WithMessage("End date must be after start date.");
        }
    }
}
