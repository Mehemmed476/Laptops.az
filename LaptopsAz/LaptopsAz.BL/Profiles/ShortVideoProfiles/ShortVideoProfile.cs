using AutoMapper;
using LaptopsAz.BL.DTOs.ShortVideoDtos;
using LaptopsAz.Core.Models;

namespace LaptopsAz.BL.Profiles.ShortVideoProfiles;

public class ShortVideoProfile : Profile
{
    public ShortVideoProfile()
    {
        CreateMap<ShortVideo, ShortVideoGetDto>().ReverseMap();
        CreateMap<ShortVideo, ShortVideoPostDto>().ReverseMap();
        CreateMap<ShortVideo, ShortVideoPutDto>().ReverseMap();
        CreateMap<ShortVideoGetDto, ShortVideoPutDto>().ReverseMap();
    }
}