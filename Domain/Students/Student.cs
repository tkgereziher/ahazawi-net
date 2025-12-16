using Ahazawi.Domain.Abstractions;
using Ahazawi.Domain.Common;

namespace Ahazawi.Domain.Students;

public class Student : BaseEntity<StudentId>, IAggregateRoot
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }

    // Ef Core constructor
    private Student() { }

    public Student(StudentId id, string firstName, string lastName, string email)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public static Student Create(string firstName, string lastName, string email)
    {
        return new Student(StudentId.New(), firstName, lastName, email);
    }
}
