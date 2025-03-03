namespace Ambev.DeveloperEvaluation.Domain.Common;

/// <summary>
/// Defines that the current class is a Entity on database and need to implement the Id identify.
/// </summary>
public interface IEntity
{
    /// <summary>
    /// Get or sets the current identify of this class.
    /// </summary>
    Guid Id { get; set; }
}