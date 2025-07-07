using AutoMapper;
using LaptopsAz.BL.DTOs.ReviewDtos;
using LaptopsAz.Core.Models;

namespace LaptopsAz.BL.Profiles.ReviewProfiles;

public class ReviewProfile : Profile
{
    public ReviewProfile()
    {
        CreateMap<ReviewGetDto, ReviewPutDto>().ReverseMap();
        CreateMap<ReviewGetDto, Review>().ReverseMap();
        CreateMap<ReviewPostDto, Review>().ReverseMap();
        CreateMap<ReviewPutDto, Review>().ReverseMap();
    }
}