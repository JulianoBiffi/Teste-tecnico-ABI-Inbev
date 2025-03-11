using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Product.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Product.GetProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;
using Ambev.DeveloperEvaluation.Application.Product.GetProducts;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts;
using Ambev.DeveloperEvaluation.Common.Pagination;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products;

/// <summary>
/// Controller for managing products operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ProductsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ProductsController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public ProductsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new product
    /// </summary>
    /// <param name="request">The product creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created product details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateProductResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProducts([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateProductRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateProductCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateProductResponse>
        {
            Success = true,
            Message = "Product created successfully",
            Data = _mapper.Map<CreateProductResponse>(response)
        });
    }

    /// <summary>
    /// Gets a product by ID
    /// </summary>
    /// <param name="id">The product ID</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product details</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetProductResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProduct([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetProductRequest { Id = id };
        var validator = new GetProductRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = new GetProductCommand(id);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<GetProductResponse>
        {
            Success = true,
            Message = "Product retrieved successfully",
            Data = _mapper.Map<GetProductResponse>(response)
        });
    }

    /// <summary>
    /// Gets a list of products with pagination
    /// </summary>
    /// <param name="page">The page number for pagination (default: 1)</param>
    /// <param name="size">The number of items per page (default: 10)</param>
    /// <param name="order">The ordering of results (e.g., "price desc, title asc")</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A paginated list of products</returns>
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponseWithData<PaginatedList<GetProductsResult>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProducts([FromQuery] int? _page, [FromQuery] int? _size, [FromQuery] string? _order, CancellationToken cancellationToken)
    {
        var currentRequest =
            new GetProductsRequest()
            {
                Page = _page ?? 1,
                Size = _size ?? 10,
                Order = _order
            };

        var validator = new GetProductsRequestValidator();
        var validationResult = await validator.ValidateAsync(currentRequest, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetProductsCommand>(currentRequest);
        var response = await _mediator.Send(command, cancellationToken);

        return OkPaginated(response);
    }
}
