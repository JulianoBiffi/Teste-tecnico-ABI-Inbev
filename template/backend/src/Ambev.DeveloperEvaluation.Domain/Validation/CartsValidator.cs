using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class CartsValidator : AbstractValidator<Carts>
{
    public CartsValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("User id must be provided and valid!");

        RuleFor(x => x.CreationDate)
            .NotEmpty()
            .WithMessage("Creation date should be valid!");

        RuleFor(x => x.LastChangeDate)
            .NotEmpty()
            .WithMessage("LastChange date should be valid!");
    }
}