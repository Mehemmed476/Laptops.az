using AutoMapper;
using LaptopsAz.BL.DTOs.ProductPhotoDtos;
using LaptopsAz.Core.Models;

namespace LaptopsAz.BL.Profiles.ProductPhotoProfiles;

public class ProductPhotoProfile : Profile
{
    public ProductPhotoProfile()
    {
        CreateMap<ProductPhotoGetDto, ProductPhoto>().ReverseMap()
            .ForMember(dest => dest.ImageURL, opt => opt.MapFrom(src => src.PhotoURL));
        CreateMap<ProductPhotoPostDto, ProductPhoto>().ReverseMap()
            .ForMember(dest => dest.ImageURL, opt => opt.MapFrom(src => src.PhotoURL));
        CreateMap<ProductPhotoPutDto, ProductPhoto>().ReverseMap()
            .ForMember(dest => dest.ImageURL, opt => opt.MapFrom(src => src.PhotoURL));
        CreateMap<ProductPhotoGetDto, ProductPhotoPutDto>().ReverseMap();
    }
}