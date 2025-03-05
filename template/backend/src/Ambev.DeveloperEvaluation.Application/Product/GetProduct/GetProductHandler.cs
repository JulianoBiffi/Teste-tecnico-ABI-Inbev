using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Product.GetProduct;

/// <summary>
/// Handler for processing GetProductCommand requests
/// </summary>
public class GetProductHandler : IRequestHandler<GetProductCommand, GetProductResult>
{
    private readonly IProductsRepository _productsRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetProductHandler
    /// </summary>
    /// <param name="productsRepository">The products repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public GetProductHandler(
        IProductsRepository productsRepository,
        IMapper mapper)
    {
        _productsRepository = productsRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetProductCommand request
    /// </summary>
    /// <param name="request">The GetProduct command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product details if found</returns>
    public async Task<GetProductResult> Handle(GetProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetProductValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var currentProduct = await _productsRepository.GetByIdAsync(request.Id, cancellationToken);
        if (currentProduct == null)
            throw new KeyNotFoundException($"Product with ID {request.Id} not found");

        return _mapper.Map<GetProductResult>(currentProduct);
    }
}