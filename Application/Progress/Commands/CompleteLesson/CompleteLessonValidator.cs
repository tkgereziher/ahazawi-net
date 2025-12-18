using FluentValidation;

namespace Momona.Application.Progress.Commands.CompleteLesson;

public class CompleteLessonValidator : AbstractValidator<CompleteLessonCommand>
{
    public CompleteLessonValidator()
    {
        RuleFor(x => x.StudentId).NotEmpty();
        RuleFor(x => x.CourseId).NotEmpty();
        RuleFor(x => x.LessonId).NotEmpty();
    }
}
