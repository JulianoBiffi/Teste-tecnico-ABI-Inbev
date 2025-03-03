using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for <see cref="Carts"/> entity operations
/// </summary>
public interface ICartsRepository
{
    /// <summary>
    /// Creates a new <see cref="Carts"/> at the database
    /// </summary>
    /// <param name="currentCart">The <see cref="Carts"/> to be created</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created <see cref="Carts"/></returns>
    Task<Carts> CreateAsync(Carts currentCart, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a <see cref="Carts"/> from the database
    /// </summary>
    /// <param name="id">The unique identifier of the <see cref="Carts"/> to be deleted</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the <see cref="Carts"/> was deleted, false if not found</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a <see cref="Carts"/> by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the <see cref="Carts"/></param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The <see cref="Carts"/> if found, null otherwise</returns>
    Task<Carts?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves every <see cref="Carts"/> of the database.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Every <see cref="Carts"/> that was found in the table</returns>
    Task<IEnumerable<Carts>> GetAllAsync(CancellationToken cancellationToken = default);
}
