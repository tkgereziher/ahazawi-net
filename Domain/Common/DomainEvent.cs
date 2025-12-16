using Ahazawi.Domain.Abstractions;

namespace Ahazawi.Domain.Common;

public abstract record DomainEvent(Guid Id);

// Stub for INotification if MediatR is not referenced in Domain (usually it is, or we define our own)
// But usually Domain doesn't depend on MediatR. 
// However, the user request showed DomainEvent.
// I'll make it a simple record for now.
// If MediatR is needed, we should add it to Domain or just define interface.
// Let's stick to simple record.

/*
public interface IDomainEvent 
{
    Guid Id { get; }
}
*/
