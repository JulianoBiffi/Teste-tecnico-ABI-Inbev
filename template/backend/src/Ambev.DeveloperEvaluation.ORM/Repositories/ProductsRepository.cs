using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of <see cref="IProductsRepository"/> using Entity Framework Core
/// </summary>
public class ProductsRepository : BaseRepository<Products, DefaultContext>, IProductsRepository
{
    /// <summary>
    /// Initializes a new instance of <see cref="ProductsRepository"/>
    /// </summary>
    /// <param name="context">The database context</param>
    public ProductsRepository(DefaultContext context) : base(context) { }

    /// <inheritdoc/>
    public async Task<Products> CreateAsync(Products currentProduct, CancellationToken cancellationToken = default)
        => await AddAsync(currentProduct, cancellationToken);

    /// <inheritdoc/>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
        => await RemoveAsync(id, cancellationToken);

    /// <inheritdoc/>
    public async Task<IEnumerable<Products>> GetAllAsync(CancellationToken cancellationToken = default)
        => await base.GetAllAsync(cancellationToken);

    /// <inheritdoc/>
    public async Task<Products?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await base.GetByIdAsync(id, cancellationToken);

    /// <inheritdoc/>
    public async Task<IEnumerable<Products>> GetAllPagedAsync(int page, int size, string? order, CancellationToken cancellationToken = default)
    {
        return await base.GetAllPagedAsync(page, size, order, cancellationToken);
    }
}
