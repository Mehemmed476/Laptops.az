using LaptopsAz.BL.DTOs.IdentityDtos;
using LaptopsAz.BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
namespace LaptopsAz.PL.Controllers;

public class IdentityController : Controller
{
    private readonly IIdentityService _identityService;


    public IdentityController(IIdentityService identityService)
    {
        _identityService = identityService;

    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        try
        {
            await _identityService.LoginAsync(dto);
            return RedirectToAction("Index", "Dashboard", new { area = "MexfiErazi" });
        }
        catch (Exception ex)
        {
            return RedirectToAction("Index", "Error");
        }
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        try
        {
            await _identityService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
        catch (Exception ex)
        {
            return RedirectToAction("Index", "Error");
        }
    }

}