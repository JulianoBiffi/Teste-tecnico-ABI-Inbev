using Ambev.DeveloperEvaluation.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Genate abstract method to facilitate the conversation with <see cref="TEntity"/> and <see cref="TContext"/>
/// </summary>
/// <typeparam name="TEntity">Current entity which you wanna abstract the methods</typeparam>
/// <typeparam name="TContext">Current context of the application</typeparam>
public abstract class BaseRepository<TEntity, TContext> where TEntity : class, IEntity where TContext : DefaultContext
{
    /// <summary>
    /// Defines current application context, used to communicate with postgres
    /// </summary>
    protected readonly TContext _Context;

    public BaseRepository(TContext context) => (_Context) = (context);

    /// <summary>
    /// Asynchronously adds a new entity of type <typeparamref name="TEntity"/> to the database context and saves the changes.
    /// <para>
    /// This method adds the provided <paramref name="currentObjectEntity"/> to the database context and persists the changes to the database.
    /// If the operation is successful, the method returns the added entity.
    /// </para>
    /// </summary>
    /// <param name="currentObjectEntity">The object to be saved on database</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>Instance of <paramref name="currentObjectEntity"/> saved in the database.</returns>
    /// <exception cref="ArgumentNullException">When <paramref name="currentObjectEntity"/> is null</exception>
    protected virtual async Task<TEntity> AddAsync(TEntity currentObjectEntity, CancellationToken cancellationToken = default)
    {
        if (currentObjectEntity is null)
        {
            throw new ArgumentNullException(nameof(currentObjectEntity));
        }

        await _Context.Set<TEntity>().AddAsync(currentObjectEntity, cancellationToken);
        await _Context.SaveChangesAsync(cancellationToken);

        return currentObjectEntity;
    }

    /// <summary>
    /// Asynchronously retrieves an entity of type <typeparamref name="TEntity"/> by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to be retrieved.</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns> A task with the entity of type <typeparamref name="TEntity"/> if found; otherwise, null.
    /// </returns>
    protected virtual async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return
            await _Context.Set<TEntity>()
                          .FirstOrDefaultAsync(objectAtEntity => objectAtEntity.Id == id, cancellationToken);
    }

    /// <summary>
    /// Asynchronously deletes an record of type <typeparamref name="TEntity"/> from the database context and saves the changes.
    /// <para>The remove method is synchronously.</para>
    /// </summary>
    /// <param name="id">The unique identifier of the entity to be deleted.</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns><see cref="true"/> when the item has been deleted or false when is not found.</returns>
    /// <exception cref="ArgumentNullException">When <paramref name="currentObjectEntity"/> is null</exception>
    protected virtual async Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var currentObjectEntity =
            await GetByIdAsync(id, cancellationToken);

        if (currentObjectEntity is null)
        {
            return false;
        }

        _Context.Set<TEntity>().Remove(currentObjectEntity);

        await _Context.SaveChangesAsync(cancellationToken);

        return true;
    }

    /// <summary>
    /// Asynchronously retrieves every entity of type <typeparamref name="TEntity"/> from the database context.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>List with every records or empty otherwise.</returns>
    protected virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _Context.Set<TEntity>().ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Retrieves the <see cref="IQueryable"/> of every records of <typeparamref name="TEntity"/> from the database context, and apply the orderby when is provided.
    /// </summary>
    /// <param name="order">The order by clause like: Something desc, AnotherThing asc</param>
    /// <returns><see cref="IQueryable"/> of records</returns>
    protected virtual IQueryable<TEntity> GetAllQueryableOrdered(string? order = null)
    {
        var currentQueryable =
            _Context.Set<TEntity>()
                    .AsQueryable();

        if (!string.IsNullOrEmpty(order))
        {
            var currentAvailableProperties =
                typeof(TEntity).GetProperties()
                               .Select(p => p.Name)
                               .ToHashSet(StringComparer.OrdinalIgnoreCase);

            bool canBeOrdered =
                order.Split(',')
                     .Select(field => field.Trim().Split(' ')[0])
                     .All(currentAvailableProperties.Contains);

            if (canBeOrdered)
            {
                var orderClause =
                    string.Join(
                        ",",
                        order.Split(',')
                             .Select(field => field.Trim()
                                                   .Replace(" asc", " ascending", StringComparison.OrdinalIgnoreCase)
                                                   .Replace(" desc", " descending", StringComparison.OrdinalIgnoreCase)));

                currentQueryable =
                    currentQueryable.OrderBy(orderClause);
            }
        }

        return currentQueryable;
    }
}