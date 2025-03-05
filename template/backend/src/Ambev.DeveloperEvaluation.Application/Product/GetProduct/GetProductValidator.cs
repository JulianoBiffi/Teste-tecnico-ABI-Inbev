using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Product.GetProduct;

/// <summary>
/// Validator for GetProductCommand
/// </summary>
public class GetProductValidator : AbstractValidator<GetProductCommand>
{
    /// <summary>
    /// Initializes validation rules for GetProductCommand
    /// </summary>
    public GetProductValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("The product ID should be provided")
            .Must(id => Guid.TryParse(id.ToString(), out _))
            .WithMessage("The product ID should be a valid GUID");
    }
}