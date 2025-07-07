using Microsoft.AspNetCore.Http;

namespace LaptopsAz.BL.DTOs.CategoryDtos;

public class CategoryPostDto
{
    public string CategoryName { get; set; }
    public IFormFile Image { get; set; }
    public bool IsTop { get; set; }
}