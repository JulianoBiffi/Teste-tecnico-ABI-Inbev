using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Product.CreateProduct;

/// <summary>
/// Command for creating a new product.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a product
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="CreateProductResult"/>.
/// The data provided in this command is validated using the 
/// <see cref="CreateProductCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class CreateProductCommand : IRequest<CreateProductResult>
{
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
    /// Gets or sets if current product is active
    /// </summary>
    public bool Active { get; set; } = true;

    public ValidationResultDetail Validate()
    {
        var validator = new CreateProductCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}