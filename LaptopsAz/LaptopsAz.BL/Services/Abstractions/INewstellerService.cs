using LaptopsAz.BL.DTOs.NewstellerDtos;

namespace LaptopsAz.BL.Services.Abstractions;

public interface INewstellerService
{
    Task CreateNewstellerAsync(NewstellerPostDto dto);
    Task DeleteNewstellerAsync(Guid id);
    Task SoftDeleteNewstellerAsync(Guid id);
    Task RestoreNewstellerAsync(Guid id);
    Task UpdateNewstellerAsync(NewstellerPutDto dto);
    Task<ICollection<NewstellerGetDto>> GetAllActiveNewsteller(int size = 10, int page = 0);
    Task<ICollection<NewstellerGetDto>> GetAllSoftDeletedNewsteller(int size = 10, int page = 0);
    Task<NewstellerGetDto> GetByIdNewstellerAsync(Guid id);
}