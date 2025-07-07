using LaptopsAz.BL.DTOs.BrandSliderDtos;
using LaptopsAz.BL.DTOs.CategoryDtos;
using LaptopsAz.BL.DTOs.NewstellerDtos;
using LaptopsAz.BL.DTOs.ProductDtos;
using LaptopsAz.BL.DTOs.ShortVideoDtos;
using LaptopsAz.BL.DTOs.SliderItemDtos;
using LaptopsAz.Core.Models;

namespace LaptopsAz.PL.ViewModels.HomeVMs;

public class HomeVM
{
    public ICollection<SliderItemGetDto>? SliderItems { get; set; }
    public ICollection<BrandSliderGetDto>? BrandSliders { get; set; }
    public ICollection<ProductGetDto>? NewProducts { get; set; }
    public ICollection<ProductGetDto>? Products { get; set; }
    public ICollection<CategoryGetDto>? Categories { get; set; }
    public ICollection<ProductGetDto>? OurProducts { get; set; }
    public ICollection<ProductGetDto>? NewestProducts { get; set; }
    public ICollection<ProductGetDto>? BestSellers { get; set; }
    public ICollection<ProductGetDto>? HotDeals { get; set; }
    public ICollection<ShortVideoGetDto>? Shorts { get; set; }
    public NewstellerPostDto NewstellerPostDto { get; set; }
}