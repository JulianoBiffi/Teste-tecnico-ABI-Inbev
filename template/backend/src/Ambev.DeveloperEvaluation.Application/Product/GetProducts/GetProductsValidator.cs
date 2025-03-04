using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Product.GetProducts;

/// <summary>
/// Validator for GetProductsQuery
/// </summary>
public class GetProductsValidator : AbstractValidator<GetProductsCommand>
{
    public GetProductsValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThan(0)
            .WithMessage("Page must be greater than 0");

        RuleFor(x => x.Size)
            .GreaterThan(0)
            .LessThanOrEqualTo(100)
            .WithMessage("Size must be between 1 and 100");

        RuleFor(x => x.Order)
            .Matches(@"^[a-zA-Z]+( [a-zA-Z]+)?( (asc|desc))?$")
            .WithMessage("Order must follow the format 'field (asc|desc)'");
    }
}