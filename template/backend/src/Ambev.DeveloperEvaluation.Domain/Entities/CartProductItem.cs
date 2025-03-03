using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents each item of <see cref="Carts"/>.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class CartProductItem : BaseEntity
{
    /// <summary>
    /// Gets or sets the cart that owns this item.
    /// </summary>
    public Guid CartId { get; set; }

    /// <summary>
    /// Gets or sets the product that is added into this cart.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets or sets the quantity of this product in the cart.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Represents the instance of the <see cref="Carts"/> entity that owns this item.
    /// </summary>
    public virtual Carts Cart { get; set; }

    /// <summary>
    /// Represents the instance of the <see cref="Products"/> entity that is added into this cart.
    /// </summary>
    public virtual Products Products { get; set; }

    /// <summary>
    /// Performs validation of the <see cref="CartProductItem"/> entity using the <see cref="CartProductItemValidator"/> rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet"><see cref="CartId"/>Should be valid</list>
    /// <list type="bullet"><see cref="ProductId"/>Should be valid</list>
    /// <list type="bullet"><see cref="Quantity"/>Should be greater than 0!</list>
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new CartProductItemValidator();
        var result = validator.Validate(this);
        return
            new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
    }
}