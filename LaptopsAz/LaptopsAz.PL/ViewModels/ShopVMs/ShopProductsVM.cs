using LaptopsAz.BL.DTOs.NewstellerDtos;
using LaptopsAz.BL.DTOs.ProductDtos;

namespace LaptopsAz.PL.ViewModels.ShopVMs;

public class ShopProductsVM
{
    public ICollection<ProductGetDto>? ProductsGrid { get; set; }
    public ICollection<ProductGetDto>? ProductsList { get; set; }
    public ShopFilterVM? ShopFilterVM { get; set; }
    public NewstellerPostDto NewstellerPostDto { get; set; }
    public string ViewMode { get; set; }
    public int TotalCount { get; set; }
    public int CurrentPageForList { get; set; }
    public int CurrentPageForGrid { get; set; }
    public int PageSizeForList { get; set; }
    public int PageSizeForGrid { get; set; }
    public int TotalPagesForList => (int)Math.Ceiling((decimal)TotalCount / PageSizeForList);
    public int TotalPagesForGrid => (int)Math.Ceiling((decimal)TotalCount / PageSizeForGrid);
}