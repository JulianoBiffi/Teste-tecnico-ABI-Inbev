namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Represents a request to create a new product in the system.
/// </summary>
public class CreateProductRequest
{
    /// <summary>
    /// Gets or sets the title of product.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the price of product.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the description of product.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the category of product.
    /// </summary>
    public string Category { get; set; } = string.Empty;

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
    public string? Image { get; set; } = default;
}