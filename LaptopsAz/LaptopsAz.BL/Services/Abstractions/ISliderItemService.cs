using LaptopsAz.BL.DTOs.SliderItemDtos;

namespace LaptopsAz.BL.Services.Abstractions;

public interface ISliderItemService
{
    Task CreateSliderItemAsync(SliderItemPostDto dto);
    Task DeleteSliderItemAsync(Guid id);
    Task SoftDeleteSliderItemAsync(Guid id);
    Task RestoreSliderItemAsync(Guid id);
    Task UpdateSliderItemAsync(SliderItemPutDto dto);
    Task<ICollection<SliderItemGetDto>> GetAllActiveSliderItem(int size = 10, int page = 0);
    Task<ICollection<SliderItemGetDto>> GetAllSoftDeletedSliderItem(int size = 10, int page = 0);
    Task<SliderItemGetDto> GetByIdSliderItemAsync(Guid id);
}