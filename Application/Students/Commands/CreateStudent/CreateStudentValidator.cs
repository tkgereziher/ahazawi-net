using FluentValidation;

namespace Momona.Application.Students.Commands.CreateStudent;

public class CreateStudentValidator : AbstractValidator<CreateStudentCommand>
{
    public CreateStudentValidator()
    {
        RuleFor(v => v.FirstName)
            .MaximumLength(200)
            .NotEmpty();
            
        RuleFor(v => v.LastName)
            .MaximumLength(200)
            .NotEmpty();

        RuleFor(v => v.Email)
            .MaximumLength(200)
            .NotEmpty()
            .EmailAddress();
    }
}
