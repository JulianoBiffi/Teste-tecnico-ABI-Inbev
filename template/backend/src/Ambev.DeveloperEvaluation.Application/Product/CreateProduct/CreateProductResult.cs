
using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Application.Product.CreateProduct;

/// <summary>
/// Represents the response returned after successfully creating a new product.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly created product,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class CreateProductResult
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

    /// <summary>
    /// Gets or sets the rating of product.
    /// </summary>
    public ProductsRating Rating { get; set; }
}