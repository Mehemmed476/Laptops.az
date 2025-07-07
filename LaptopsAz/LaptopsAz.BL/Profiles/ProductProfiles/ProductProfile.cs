using AutoMapper;
using LaptopsAz.BL.DTOs.ProductDtos;
using LaptopsAz.Core.Models;

namespace LaptopsAz.BL.Profiles.ProductProfiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductGetDto, ProductPutDto>().ReverseMap();
        CreateMap<ProductGetDto, Product>().ReverseMap();
        CreateMap<ProductPostDto, Product>().ReverseMap();
        CreateMap<ProductPutDto, Product>().ReverseMap();
    }
}