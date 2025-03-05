using Ambev.DeveloperEvaluation.Common.Pagination;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Product.GetProducts;

/// <summary>
/// Command for retrieving a list of Products
/// </summary>
public class GetProductsCommand : IRequest<PaginatedList<GetProductsResult>>
{
    /// <summary>
    /// The page number for pagination (default: 1)
    /// </summary>
    public int Page { get; set; } = 1;

    /// <summary>
    /// The size of items per page (default: 10)
    /// </summary>
    public int Size { get; set; } = 10;

    /// <summary>
    /// The order for sorting the products
    /// </summary>
    public string? Order { get; set; }
}
