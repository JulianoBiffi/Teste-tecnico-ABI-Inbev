using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of <see cref="ICartProductItemRepository"/> using Entity Framework Core
/// </summary>
public class CartProductItemRepository : BaseRepository<CartProductItem, DefaultContext>, ICartProductItemRepository
{
    /// <summary>
    /// Initializes a new instance of <see cref="CartProductItemRepository"/>
    /// </summary>
    /// <param name="context">The database context</param>
    public CartProductItemRepository(DefaultContext context) : base(context) { }

    /// <inheritdoc/>
    public async Task<CartProductItem> CreateAsync(CartProductItem currentCart, CancellationToken cancellationToken = default)
        => await AddAsync(currentCart, cancellationToken);

    /// <inheritdoc/>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
        => await RemoveAsync(id, cancellationToken);

    /// <inheritdoc/>
    public async Task<IEnumerable<CartProductItem>> GetAllAsync(CancellationToken cancellationToken = default)
        => await base.GetAllAsync(cancellationToken);

    /// <inheritdoc/>
    public async Task<CartProductItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await base.GetByIdAsync(id, cancellationToken);
}
