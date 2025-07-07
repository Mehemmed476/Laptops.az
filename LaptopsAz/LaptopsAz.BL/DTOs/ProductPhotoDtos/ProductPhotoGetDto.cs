using LaptopsAz.Core.Models;

namespace LaptopsAz.BL.DTOs.ProductPhotoDtos;

public class ProductPhotoGetDto
{
    public Guid Id { get; set; }
    public string ImageURL { get; set; }
    public Guid ProductId { get; set; }
}