using LaptopsAz.BL.DTOs.NewstellerDtos;
using LaptopsAz.BL.DTOs.ProductDtos;
using LaptopsAz.BL.DTOs.ProductPhotoDtos;
using LaptopsAz.BL.DTOs.ProductSpecDtos;
using LaptopsAz.BL.DTOs.ReviewDtos;

namespace LaptopsAz.PL.ViewModels.ShopVMs;

public class ProductDetailVM
{
    public ProductGetDto Product { get; set; }
    public ICollection<ProductGetDto> LatestProducts { get; set; }
    public ICollection<ProductSpecGetDto> ProductSpecs { get; set; }
    public ICollection<ReviewGetDto> Reviews { get; set; }
    public ICollection<ProductPhotoGetDto> Photos { get; set; }
    public ReviewPostDto ReviewPost { get; set; }
    public NewstellerPostDto NewstellerPostDto { get; set; }
}