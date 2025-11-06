using System.Reflection;

namespace Poe.Domain.Core.EntityBaseAbstractions;

public abstract class EntityBase
{
    public Guid Id { get; set; } 
    public DateTime CreatedAt { get; set; }
}