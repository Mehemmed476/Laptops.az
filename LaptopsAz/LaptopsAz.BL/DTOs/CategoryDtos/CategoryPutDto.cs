using Microsoft.AspNetCore.Http;

namespace LaptopsAz.BL.DTOs.CategoryDtos;

public class CategoryPutDto
{
    public Guid Id { get; set; }
    public string CategoryName { get; set; }
    public IFormFile? Image { get; set; }
    public string ImageURL { get; set; }
    public bool IsTop { get; set; }
}