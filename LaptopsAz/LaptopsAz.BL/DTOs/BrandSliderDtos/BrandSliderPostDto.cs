using Microsoft.AspNetCore.Http;

namespace LaptopsAz.BL.DTOs.BrandSliderDtos;

public class BrandSliderPostDto
{
    public string Title { get; set; }
    public IFormFile Image { get; set; }
}