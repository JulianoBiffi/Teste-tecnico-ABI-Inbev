using Ambev.DeveloperEvaluation.Application.Product.GetProduct;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

/// <summary>
/// Profile for mapping between Application and API <see cref="GetProduct"/> responses
/// </summary>
public class GetProductProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for <see cref="GetProduct"/> feature
    /// </summary>
    public GetProductProfile()
    {
        CreateMap<GetProductResult, GetProductResponse>()
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => new ProductsRating(src.RatingRate, src.RatingCount)));
    }
}