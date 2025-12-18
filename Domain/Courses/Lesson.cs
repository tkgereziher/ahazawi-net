using Momona.Domain.Common;

namespace Momona.Domain.Courses;

public class Lesson : BaseEntity<Guid>
{
    public string Title { get; private set; }
    public string Content { get; private set; } // URL or text
    public Guid ModuleId { get; private set; }

    private Lesson() { }

    public Lesson(Guid id, string title, string content, Guid moduleId)
    {
        Id = id;
        Title = title;
        Content = content;
        ModuleId = moduleId;
    }
}
