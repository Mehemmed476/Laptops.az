using AutoMapper;
using LaptopsAz.BL.DTOs.ProductSpecDtos;
using LaptopsAz.Core.Models;

namespace LaptopsAz.BL.Profiles.ProductSpecProfiles;

public class ProductSpecProfile : Profile
{
    public ProductSpecProfile()
    {
        CreateMap<ProductSpecGetDto, ProductSpecPutDto>().ReverseMap();
        CreateMap<ProductSpecGetDto, ProductSpec>().ReverseMap();
        CreateMap<ProductSpecPostDto, ProductSpec>().ReverseMap();
        CreateMap<ProductSpecPutDto, ProductSpec>().ReverseMap();
    }
}