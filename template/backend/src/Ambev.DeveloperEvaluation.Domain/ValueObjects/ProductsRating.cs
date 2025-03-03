namespace Ambev.DeveloperEvaluation.Domain.ValueObjects;

/// <summary>
/// Represents the rating of a product.
/// </summary>
public class ProductsRating
{
    /// <summary>
    /// Gets the average rating of the product.
    /// </summary>
    public decimal Rate { get; }

    /// <summary>
    /// Gets the total number of ratings of the product.
    /// </summary>
    public long Count { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductsRating"/> class.
    /// </summary>
    /// <param name="rate">The average of rating in this product</param>
    /// <param name="count">The number of user's rating</param>
    public ProductsRating(decimal rate, long count)
    {
        Rate = rate;
        Count = count;
    }
}