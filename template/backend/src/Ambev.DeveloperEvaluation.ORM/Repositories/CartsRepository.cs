using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of <see cref="ICartsRepository"/> using Entity Framework Core
/// </summary>
public class CartsRepository : BaseRepository<Carts, DefaultContext>, ICartsRepository
{
    /// <summary>
    /// Initializes a new instance of <see cref="CartsRepository"/>
    /// </summary>
    /// <param name="context">The database context</param>
    public CartsRepository(DefaultContext context) : base(context) { }

    /// <inheritdoc/>
    public async Task<Carts> CreateAsync(Carts currentCart, CancellationToken cancellationToken = default)
        => await AddAsync(currentCart, cancellationToken);

    /// <inheritdoc/>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
        => await RemoveAsync(id, cancellationToken);

    /// <inheritdoc/>
    public async Task<IEnumerable<Carts>> GetAllAsync(CancellationToken cancellationToken = default)
        => await base.GetAllAsync(cancellationToken);

    /// <inheritdoc/>
    public async Task<Carts?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await base.GetByIdAsync(id, cancellationToken);
}
