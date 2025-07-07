using AutoMapper;
using LaptopsAz.BL.DTOs.SliderItemDtos;
using LaptopsAz.Core.Models;

namespace LaptopsAz.BL.Profiles.SliderItemProfiles;

public class SliderItemProfile  : Profile
{
    public SliderItemProfile()
    {
        CreateMap<SliderItemGetDto, SliderItem>().ReverseMap();
        CreateMap<SliderItemPostDto, SliderItem>().ReverseMap();
        CreateMap<SliderItemPutDto, SliderItem>().ReverseMap();
        CreateMap<SliderItemPutDto, SliderItemGetDto>().ReverseMap();
    }
}