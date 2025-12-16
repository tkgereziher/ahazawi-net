using Ahazawi.Domain.Common;

namespace Ahazawi.Domain.Courses;

public class Module : BaseEntity<Guid>
{
    public string Title { get; private set; }
    public Guid CourseId { get; private set; }
    
    private readonly List<Lesson> _lessons = new();
    public IReadOnlyCollection<Lesson> Lessons => _lessons.AsReadOnly();

    private Module() { }

    public Module(Guid id, string title, Guid courseId)
    {
        Id = id;
        Title = title;
        CourseId = courseId;
    }
}
