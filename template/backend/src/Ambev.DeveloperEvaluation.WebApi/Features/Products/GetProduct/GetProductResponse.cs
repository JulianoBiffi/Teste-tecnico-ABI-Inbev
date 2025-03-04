using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

/// <summary>
/// Represents a response to get a product by its ID
/// </summary>
public class GetProductResponse
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
    /// Gets or sets the image of product.
    /// </summary>
    public string? Image { get; set; }

    /// <summary>
    /// Gets or sets the rating of product.
    /// </summary>
    public ProductsRating Rating { get; set; }
}
