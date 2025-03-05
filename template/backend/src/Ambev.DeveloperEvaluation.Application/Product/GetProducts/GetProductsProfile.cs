using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Product.GetProducts;

/// <summary>
/// Profile for mapping between Product entity and GetProducts
/// </summary>
public class GetProductsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetProduct operation
    /// </summary>
    public GetProductsProfile()
    {
        CreateMap<Products, GetProductsResult>()
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => new ProductsRating(src.RatingRate, src.RatingCount)));
    }
}