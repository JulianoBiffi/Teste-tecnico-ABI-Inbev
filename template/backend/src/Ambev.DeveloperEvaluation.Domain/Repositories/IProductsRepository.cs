using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for <see cref="Products"/> entity operations
/// </summary>
public interface IProductsRepository
{
    /// <summary>
    /// Creates a new <see cref="Products"/> at the database
    /// </summary>
    /// <param name="currentProduct">The <see cref="Products"/> to be created</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created <see cref="Products"/></returns>
    Task<Products> CreateAsync(Products currentProduct, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a <see cref="Products"/> from the database
    /// </summary>
    /// <param name="id">The unique identifier of the <see cref="Products"/> to be deleted</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the <see cref="Products"/> was deleted, false if not found</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a <see cref="Products"/> by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the <see cref="Products"/></param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The <see cref="Products"/> if found, null otherwise</returns>
    Task<Products?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves every <see cref="Products"/> of the database.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Every <see cref="Products"/> that was found in the table</returns>
    Task<IEnumerable<Products>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves every <see cref="Products"/> of the database, paged.
    /// </summary>
    /// <param name="page">The current page</param>
    /// <param name="size">Total size of page</param>
    /// <param name="order">The order to be paged</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The list of <see cref="Products"/> with expected records</returns>
    Task<IEnumerable<Products>> GetAllPagedAsync(
        int page = 1,
        int size = 10,
        string? order = null,
        CancellationToken cancellationToken = default);
}
