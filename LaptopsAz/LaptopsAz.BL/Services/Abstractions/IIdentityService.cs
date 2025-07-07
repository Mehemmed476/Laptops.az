using LaptopsAz.BL.DTOs.IdentityDtos;

namespace LaptopsAz.BL.Services.Abstractions;

public interface IIdentityService
{
    Task LoginAsync(LoginDto dto);
    Task LogoutAsync();
}