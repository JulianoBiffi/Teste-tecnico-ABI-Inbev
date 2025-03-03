using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;


namespace Ambev.DeveloperEvaluation.Application.Product.CreateProduct;

/// <summary>
/// Profile for mapping between Product entity and CreateProductResponse
/// </summary>
public class CreateProductProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser operation
    /// </summary>
    public CreateProductProfile()
    {
        CreateMap<CreateProductCommand, Products>();
        CreateMap<Products, CreateProductResult>()
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => new ProductsRating(src.RatingRate, src.RatingCount)));
    }
}
