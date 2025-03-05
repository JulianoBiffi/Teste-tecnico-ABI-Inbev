using Ambev.DeveloperEvaluation.Common.Pagination;
using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts;

/// <summary>
/// Represents a request to get a list of products
/// </summary>
public class GetProductsRequest : IRequest<PaginatedList<GetProductsResponse>>
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
