using AutoMapper;
using LaptopsAz.BL.DTOs.CategoryDtos;
using LaptopsAz.Core.Models;

namespace LaptopsAz.BL.Profiles.CategoryProfiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CategoryGetDto, CategoryPutDto>().ReverseMap();
        CreateMap<CategoryGetDto, Category>().ReverseMap();
        CreateMap<CategoryPostDto, Category>().ReverseMap();
        CreateMap<CategoryPutDto, Category>().ReverseMap();
    }
}