using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a product in the system.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Products : BaseEntity
{
    /// <summary>
    /// Gets or sets the title of product.
    /// Represents the product's name or title.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the price of product.
    /// Defines the product's price in the system.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the description of product.
    /// Represents the details or description of product.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the category of product.
    /// Defines the product's category in the system.
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// Gets or sets the image of product.
    /// Define the image URL of product.
    /// </summary>
    public string? Image { get; set; }

    /// <summary>
    /// Gets or sets the rating of product.
    /// Represents the average of rating from this product.
    /// </summary>
    public decimal RatingRate { get; set; }

    /// <summary>
    /// Gets or sets the numbers of rating which this product has.
    /// Represents the number of rating which the product has.
    /// </summary>
    public long RatingCount { get; set; }

    /// <summary>
    /// Gets or sets if current product is active.
    /// Represents a soft delete flag for the product, when false the product is not available for sale.
    /// </summary>
    public bool Active { get; set; }

    /// <summary>
    /// Gets or sets the deactivation date of product.
    /// Represents the date when the product was deactivated.
    /// </summary>
    public DateTime? DeactivationDate { get; set; }

    /// <summary>
    /// Performs validation of the <see cref="Products"/> entity using the <see cref="ProductsValidator"/> rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet"><see cref="Title"/> length and avoid SQL Injections</list>
    /// <list type="bullet"><see cref="Description"/> length and avoid SQL Injections</list>
    /// <list type="bullet"><see cref="Category"/> length and avoid SQL Injections</list>
    /// <list type="bullet"><see cref="Image"/> The URL is valid the length and avoid SQL Injections</list>
    /// <list type="bullet"><see cref="Price"/>The value provided</list>
    /// <list type="bullet"><see cref="RatingRate"/>The value provided</list>
    /// <list type="bullet"><see cref="RatingCount"/>The value provided</list>
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new ProductsValidator();
        var result = validator.Validate(this);
        return
            new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
    }
}