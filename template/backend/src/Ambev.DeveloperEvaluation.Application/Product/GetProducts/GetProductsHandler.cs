using Ambev.DeveloperEvaluation.Common.Pagination;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Product.GetProducts;

public class GetProductsHandler : IRequestHandler<GetProductsCommand, PaginatedList<GetProductsResult>>
{
    private readonly IProductsRepository _productsRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetProductsHandler
    /// </summary>
    /// <param name="productsRepository">The products repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public GetProductsHandler(
        IProductsRepository productsRepository,
        IMapper mapper)
    {
        _productsRepository = productsRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetProductsCommand request
    /// </summary>
    /// <param name="request">The GetProduct command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product details if found</returns>
    public async Task<PaginatedList<GetProductsResult>> Handle(GetProductsCommand request, CancellationToken cancellationToken)
    {
        var pagedProducts =
            await _productsRepository.GetAllPagedAsync(
                page: request.Page,
                size: request.Size,
                order: request.Order,
                cancellationToken: cancellationToken);

        if (pagedProducts == null)
            throw new Exception($"Error while retrieving the list of products");

        return new PaginatedList<GetProductsResult>(
            items: _mapper.Map<List<GetProductsResult>>(pagedProducts),
            count: pagedProducts.TotalCount,
            pageNumber: pagedProducts.CurrentPage,
            pageSize: pagedProducts.PageSize
            );
    }
}