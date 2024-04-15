using AutoMapper;
using WomenClothingAPI.Application.DTOs;
using WomenClothingAPI.Models;

namespace WomenClothingAPI.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<ProductDto, Product>();
    }
}