using Microsoft.AspNetCore.Http;

namespace LaptopsAz.BL.DTOs.BrandSliderDtos;

public class BrandSliderPutDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public IFormFile? Image { get; set; }
    public string ImageURL { get; set; }
}