using FluentValidation;
using Task_Managment.DTOs.Task.Update;

namespace Task_Managment.Validations.Task
{
    public class TaskUpdateDTOValidator : AbstractValidator<TaskUpdateDTO>
    {
        public TaskUpdateDTOValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Task ID must be greater than zero.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Task title is required.")
                .MaximumLength(150).WithMessage("Task title cannot exceed 150 characters.");

            RuleFor(x => x.status)
                .IsInEnum().WithMessage("Invalid status value.");
        }
    }
}
