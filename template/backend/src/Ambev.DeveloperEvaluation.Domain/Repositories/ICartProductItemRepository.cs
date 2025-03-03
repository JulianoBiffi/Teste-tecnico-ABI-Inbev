using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for <see cref="CartProductItem"/> entity operations
/// </summary>
public interface ICartProductItemRepository
{
    /// <summary>
    /// Creates a new <see cref="CartProductItem"/> at the database
    /// </summary>
    /// <param name="currentCartProductItem">The <see cref="CartProductItem"/> to be created</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created <see cref="CartProductItem"/></returns>
    Task<CartProductItem> CreateAsync(CartProductItem currentCartProductItem, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a <see cref="CartProductItem"/> from the database
    /// </summary>
    /// <param name="id">The unique identifier of the <see cref="CartProductItem"/> to be deleted</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the <see cref="CartProductItem"/> was deleted, false if not found</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a <see cref="CartProductItem"/> by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the <see cref="CartProductItem"/></param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The <see cref="CartProductItem"/> if found, null otherwise</returns>
    Task<CartProductItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves every <see cref="CartProductItem"/> of the database.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Every <see cref="CartProductItem"/> that was found in the table</returns>
    Task<IEnumerable<CartProductItem>> GetAllAsync(CancellationToken cancellationToken = default);
}
