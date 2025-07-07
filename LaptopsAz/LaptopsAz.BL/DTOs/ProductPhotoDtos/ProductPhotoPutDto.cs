using Microsoft.AspNetCore.Http;

namespace LaptopsAz.BL.DTOs.ProductPhotoDtos;

public class ProductPhotoPutDto
{
    public Guid Id { get; set; }
    public IFormFile Image { get; set; }
    public string ImageURL { get; set; }
    public Guid ProductId { get; set; }
}