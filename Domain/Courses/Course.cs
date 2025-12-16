using Ahazawi.Domain.Abstractions;
using Ahazawi.Domain.Common;

namespace Ahazawi.Domain.Courses;

public class Course : BaseEntity<Guid>, IAggregateRoot
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    
    private readonly List<Module> _modules = new();
    public IReadOnlyCollection<Module> Modules => _modules.AsReadOnly();

    private Course() { }

    public Course(Guid id, string title, string description)
    {
        Id = id;
        Title = title;
        Description = description;
    }
}
