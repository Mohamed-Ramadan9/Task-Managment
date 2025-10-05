using FluentValidation;
using Task_Managment.DTOs.Task.Create;

namespace Task_Managment.Validations.Task
{
    public class TaskCreateDTOValidator : AbstractValidator<TaskCreateDTO>
    {
        public TaskCreateDTOValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Task title is required.")
                .MaximumLength(150).WithMessage("Task title cannot exceed 150 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

            RuleFor(x => x.ProjectId)
                .GreaterThan(0).WithMessage("Valid Project ID is required.");

            RuleFor(x => x.EndDate)
                .GreaterThan(DateTime.UtcNow)
                .WithMessage("End date must be in the future.");
        }
    }
}
