using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Product.GetProducts;

public class GetProductsHandler : IRequestHandler<GetProductsCommand, IEnumerable<GetProductsResult>>
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
    public async Task<IEnumerable<GetProductsResult>> Handle(GetProductsCommand request, CancellationToken cancellationToken)
    {
        var bunchOfProducts =
            await _productsRepository.GetAllPagedAsync(
                page: request.Page,
                size: request.Size,
                order: request.Order,
                cancellationToken: cancellationToken);

        if (bunchOfProducts == null)
            throw new Exception($"Error while retrieving the list of products");

        return _mapper.Map<IEnumerable<GetProductsResult>>(bunchOfProducts);
    }
}