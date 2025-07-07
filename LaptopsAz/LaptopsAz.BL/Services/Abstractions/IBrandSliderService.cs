using LaptopsAz.BL.DTOs.BrandSliderDtos;

namespace LaptopsAz.BL.Services.Abstractions;

public interface IBrandSliderService
{
    Task CreateBrandSliderAsync(BrandSliderPostDto dto);
    Task DeleteBrandSliderAsync(Guid id);
    Task SoftDeleteBrandSliderAsync(Guid id);
    Task RestoreBrandSliderAsync(Guid id);
    Task UpdateBrandSliderAsync(BrandSliderPutDto dto);
    Task<ICollection<BrandSliderGetDto>> GetAllActiveBrandSlider(int size = 10, int page = 0);
    Task<ICollection<BrandSliderGetDto>> GetAllSoftDeletedBrandSlider(int size = 10, int page = 0);
    Task<BrandSliderGetDto> GetByIdBrandSliderAsync(Guid id);
}