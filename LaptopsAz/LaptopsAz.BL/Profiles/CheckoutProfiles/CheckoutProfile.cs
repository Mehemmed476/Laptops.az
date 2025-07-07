using AutoMapper;
using LaptopsAz.BL.DTOs.CheckoutDtos;
using LaptopsAz.Core.Models;

namespace LaptopsAz.BL.Profiles.CheckoutProfiles;

public class CheckoutProfile : Profile
{
    public CheckoutProfile()
    {
        CreateMap<CheckoutGetDto, CheckoutPutDto>().ReverseMap();
        CreateMap<CheckoutGetDto, Checkout>().ReverseMap();
        CreateMap<CheckoutPostDto, Checkout>().ReverseMap();
        CreateMap<CheckoutPutDto, Checkout>().ReverseMap();
    }
}