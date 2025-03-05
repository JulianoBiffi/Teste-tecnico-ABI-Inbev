namespace Ambev.DeveloperEvaluation.Application.Product.GetProduct;

/// <summary>
/// Represents the response returned after successfully retrieving a product.
/// </summary>
public class GetProductResult
{
    /// <summary>
    /// The unique identifier of the created <see cref="Products"/>
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the title of product.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the price of product.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the description of product.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the category of product.
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// Gets or sets the rating of product.
    /// </summary>
    public decimal RatingRate { get; set; }

    /// <summary>
    /// Gets or sets the numbers of rating which this product has.
    /// </summary>
    public long RatingCount { get; set; }

    /// <summary>
    /// Gets or sets the image of product.
    /// </summary>
    public string? Image { get; set; }
}
