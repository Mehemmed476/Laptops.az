using LaptopsAz.BL.DTOs.NewstellerDtos;
using LaptopsAz.BL.Services.Abstractions;
using LaptopsAz.DL.Repositories.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LaptopsAz.PL.Areas.MexfiErazi.Controllers;
[Area("MexfiErazi")]
[Authorize]
public class NewstellerController : Controller
{
    private readonly INewstellerService _newstellerService;

    public NewstellerController(INewstellerService newstellerService)
    {
        _newstellerService = newstellerService;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            ICollection<NewstellerGetDto> dto = await _newstellerService.GetAllActiveNewsteller(10000);
            return View(dto);
        }
        catch (Exception e)
        {
            return RedirectToAction("Index", "Error");
        }
    }
    
    [HttpGet]       
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _newstellerService.DeleteNewstellerAsync(id);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            return RedirectToAction("Index", "Error");
        }
    }
}