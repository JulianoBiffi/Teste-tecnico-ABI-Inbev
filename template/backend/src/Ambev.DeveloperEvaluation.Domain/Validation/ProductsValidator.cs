using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class ProductsValidator : AbstractValidator<Products>
{
    public ProductsValidator()
    {
        RuleFor(product => product.Title)
            .NotEmpty()
            .WithMessage("Title cannot be empty.")
            .MaximumLength(255)
            .WithMessage("Title cannot be longer than 255 characters.")
            .SetValidator(new SqlInjectionValidator());

        RuleFor(product => product.Price)
            .GreaterThanOrEqualTo(default(decimal))
            .WithMessage($"Price must be greater than {default(decimal)}.")
            .LessThan(decimal.MaxValue)
            .WithMessage($"Price must be less than {long.MaxValue}.");

        RuleFor(product => product.Description)
            .NotEmpty().WithMessage("Description cannot be empty.")
            .MaximumLength(2500).WithMessage("Description cannot be longer than 2500 characters.")
            .SetValidator(new SqlInjectionValidator());

        RuleFor(product => product.Category)
            .NotEmpty().WithMessage("Category cannot be empty.")
            .MaximumLength(255).WithMessage("Category cannot be longer than 255 characters.")
            .SetValidator(new SqlInjectionValidator());

        RuleFor(product => product.Image)
            .MaximumLength(255)
            .WithMessage("Image URL cannot be longer than 255 characters.")
            .Must(imageUrl => Uri.TryCreate(imageUrl, UriKind.Absolute, out _))
            .When(product => !string.IsNullOrEmpty(product.Image))
            .SetValidator(new SqlInjectionValidator());

        RuleFor(product => product.RatingRate)
            .InclusiveBetween(0, 5)
            .WithMessage("Rating rate must be between 0 and 5.");

        RuleFor(product => product.RatingCount)
            .GreaterThanOrEqualTo(default(long))
            .WithMessage($"Rating count must be greater than or equal to {default(long)}.")
            .LessThan(long.MaxValue)
            .WithMessage($"Rating count must be less than {long.MaxValue}.");
    }
}