using AutoMapper;
using LaptopsAz.BL.DTOs.IdentityDtos;
using LaptopsAz.BL.Services.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace LaptopsAz.BL.Services.Implementations;

public class IdentityService : IIdentityService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IMapper _mapper;

    public IdentityService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IMapper mapper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
    }

    public async Task LoginAsync(LoginDto dto)
    {
        IdentityUser? user = await _userManager.FindByEmailAsync(dto.UsernameOrEmail);
        if (user is null)
        {
            user = await _userManager.FindByNameAsync(dto.UsernameOrEmail);
            if (user is null) { throw new Exception("Invalid login"); }
        }

        var result = await _signInManager.PasswordSignInAsync(user, dto.Password, dto.RememberMe, true);

        if (!result.Succeeded)
        {
            throw new Exception("Invalid login");
        }
    }

    public async Task LogoutAsync()
    {
        try
        {
            await _signInManager.SignOutAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Error logging out", ex);
        }
    }
}