using LaptopsAz.BL.DTOs.CheckoutDtos;

namespace LaptopsAz.BL.Services.Abstractions;

public interface ICheckoutService
{
    Task CreateCheckoutAsync(CheckoutPostDto dto);
    Task DeleteCheckoutAsync(Guid id);
    Task SoftDeleteCheckoutAsync(Guid id);
    Task RestoreCheckoutAsync(Guid id);
    Task UpdateCheckoutAsync(CheckoutPutDto dto);
    Task<ICollection<CheckoutGetDto>> GetAllActiveCheckout(int size = 10, int page = 0);
    Task<ICollection<CheckoutGetDto>> GetAllSoftDeletedCheckout(int size = 10, int page = 0);
    Task<CheckoutGetDto> GetByIdCheckoutAsync(Guid id);
}