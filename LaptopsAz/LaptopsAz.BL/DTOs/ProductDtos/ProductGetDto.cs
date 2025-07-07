using LaptopsAz.Core.Enums;
using LaptopsAz.Core.Models;

namespace LaptopsAz.BL.DTOs.ProductDtos;

public class ProductGetDto
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal DiscountPrice { get; set; }
    public Guid CategoryID { get; set; }
    public int Stock { get; set; }
    public string Brand { get; set; }
    public HomePageTagEnum? HomePageTag { get; set; }
    public string ImageURL { get; set; }
    public Category? Category { get; set; }

    public ICollection<ProductPhoto>? ProductPhotos { get; set; }
    
}