using LaptopsAz.BL.DTOs.ShortVideoDtos;

namespace LaptopsAz.BL.Services.Abstractions;

public interface IShortVideoService
{
    Task CreateShortVideoAsync(ShortVideoPostDto dto);
    Task DeleteShortVideoAsync(Guid id);
    Task SoftDeleteShortVideoAsync(Guid id);
    Task RestoreShortVideoAsync(Guid id);
    Task UpdateShortVideoAsync(ShortVideoPutDto dto);
    Task<ICollection<ShortVideoGetDto>> GetAllActiveShortVideo(int size = 10, int page = 0);
    Task<ICollection<ShortVideoGetDto>> GetAllSoftDeletedShortVideo(int size = 10, int page = 0);
    Task<ShortVideoGetDto> GetByIdShortVideoAsync(Guid id);
}