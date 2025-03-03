using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents the user's cart.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Carts : BaseEntity
{
    /// <summary>
    /// Gets or sets the user who owns the cart.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets creation date of this cart.
    /// </summary>
    public DateTime CreationDate { get; set; }

    /// <summary>
    /// Gets or sets the last change date of this cart.
    /// </summary>
    public DateTime LastChangeDate { get; set; }

    /// <summary>
    /// Represents the instance of the <see cref="Entities.User"/> entity that owns this cart.
    /// </summary>
    public virtual User User { get; set; }

    /// <summary>
    /// Represents the collection of products item in the cart.
    /// </summary>
    public virtual ICollection<CartProductItem> CartProductItems { get; set; }

    /// <summary>
    /// Performs validation of the <see cref="Carts"/> entity using the <see cref="CartsValidator"/> rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet"><see cref="UserId"/>Should be valid</list>
    /// <list type="bullet"><see cref="CreationDate"/>Should be an valid date</list>
    /// <list type="bullet"><see cref="LastChangeDate"/>Should be an valid date</list>
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new CartsValidator();
        var result = validator.Validate(this);
        return
            new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
    }
}