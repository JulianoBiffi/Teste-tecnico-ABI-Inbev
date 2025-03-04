using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

/// <summary>
/// Validator for the GetProductRequest
/// </summary>
public class GetProductRequestValidator : AbstractValidator<GetProductRequest>
{
    public GetProductRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("The product ID should be provided")
            .Must(currentId => Guid.TryParse(currentId.ToString(), out Guid _))
            .WithMessage("The provided product ID should be valid");
    }
}
