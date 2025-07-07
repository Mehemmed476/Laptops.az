using LaptopsAz.BL.DTOs.ProductDtos;
using LaptopsAz.BL.DTOs.ProductPhotoDtos;
using LaptopsAz.BL.DTOs.ProductSpecDtos;

namespace LaptopsAz.PL.Areas.MexfiErazi.ViewModels.ProductVMs;

public class DetailVm
{
    public ProductGetDto ProductGetDto { get; set; }
    public ICollection<ProductPhotoGetDto>? ProductPhotoGetDtos { get; set; }
    public ICollection<ProductSpecGetDto>? ProductSpecGetDtos { get; set; }
}