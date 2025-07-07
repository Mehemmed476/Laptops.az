using AutoMapper;
using LaptopsAz.BL.DTOs.NewstellerDtos;
using LaptopsAz.Core.Models;

namespace LaptopsAz.BL.Profiles.NewstellerProfiles;

public class NewstellerProfile : Profile
{
    public NewstellerProfile()
    {
        CreateMap<NewstellerGetDto, Newsteller>().ReverseMap();
        CreateMap<NewstellerPostDto, Newsteller>().ReverseMap();
        CreateMap<NewstellerPutDto, Newsteller>().ReverseMap();
        CreateMap<NewstellerGetDto, NewstellerPutDto>().ReverseMap();
    }
}