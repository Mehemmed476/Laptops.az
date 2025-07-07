using LaptopsAz.BL.DTOs.ProductSpecDtos;
using LaptopsAz.Core.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaptopsAz.BL.DTOs.ProductDtos;

public class ProductPostDto
{
    public string ProductName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal? DiscountPrice { get; set; }
    public Guid CategoryID { get; set; }
    public int Stock { get; set; }
    public string Brand { get; set; }
    public IFormFile Image { get; set; }
    public ICollection<IFormFile> Images { get; set; }
    public HomePageTagEnum? HomePageTag { get; set; }

    public List<ProductSpecPostDto> Specs { get; set; } = new(); // << Burada eklendi

    public ICollection<SelectListItem>? Categories { get; set; }
}