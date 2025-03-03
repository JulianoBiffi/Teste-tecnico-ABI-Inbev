using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class CartProductItemValidator : AbstractValidator<CartProductItem>
{
    public CartProductItemValidator()
    {
        RuleFor(x => x.CartId)
            .NotEmpty()
            .WithMessage("CartId must be provided and valid!");

        RuleFor(x => x.ProductId)
            .NotEmpty()
            .WithMessage("ProductId must be provided and valid!");

        RuleFor(x => x.Quantity)
            .GreaterThan(default(int))
            .WithMessage($"Quantity must be greater than {default(int)}!");
    }
}