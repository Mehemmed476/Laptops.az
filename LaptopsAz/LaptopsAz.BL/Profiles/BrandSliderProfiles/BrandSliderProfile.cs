using AutoMapper;
using LaptopsAz.BL.DTOs.BrandSliderDtos;
using LaptopsAz.Core.Models;

namespace LaptopsAz.BL.Profiles.BrandSliderProfiles;

public class BrandSliderProfile : Profile
{
    public BrandSliderProfile()
    {
        CreateMap<BrandSliderGetDto, BrandSlider>().ReverseMap();
        CreateMap<BrandSliderPostDto, BrandSlider>().ReverseMap();
        CreateMap<BrandSliderPutDto, BrandSlider>().ReverseMap();
        CreateMap<BrandSliderGetDto, BrandSliderPutDto>().ReverseMap();
    }
}