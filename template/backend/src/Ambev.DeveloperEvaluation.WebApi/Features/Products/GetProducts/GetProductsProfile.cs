using Ambev.DeveloperEvaluation.Application.Product.GetProducts;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts;

/// <summary>
/// Profile for mapping between Application and API <see cref="GetProducts"/> responses
/// </summary>
public class GetProductsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for <see cref="GetProduct"/> feature
    /// </summary>
    public GetProductsProfile()
    {
        CreateMap<GetProductsRequest, GetProductsCommand>();
    }
}