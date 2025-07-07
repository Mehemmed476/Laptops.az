using LaptopsAz.BL.DTOs.NewstellerDtos;
using LaptopsAz.BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
namespace LaptopsAz.PL.Controllers;

public class AboutUsController : Controller
{
    private readonly INewstellerService _newstellerService;
    private readonly IStringLocalizer<AboutUsController> _localizer;
    public AboutUsController(INewstellerService newstellerService, IStringLocalizer<AboutUsController> localizer)
    {
        _newstellerService = newstellerService;
        _localizer = localizer;
    }

    public IActionResult Index()
    {
        ViewData["Text1"] = _localizer["Text1"];
        ViewData["Text2"] = _localizer["Text2"];
        ViewData["Text3"] = _localizer["Text3"];
        ViewData["Text4"] = _localizer["Text4"];
        ViewData["Text5"] = _localizer["Text5"];
        ViewData["Text6"] = _localizer["Text6"];
        ViewData["Text7"] = _localizer["Text7"];
        ViewData["Text8"] = _localizer["Text8"];
        ViewData["Text9"] = _localizer["Text9"];
        ViewData["Text10"] = _localizer["Text10"];
        ViewData["Text11"] = _localizer["Text11"];
        ViewData["Text12"] = _localizer["Text12"];
        ViewData["Text13"] = _localizer["Text13"];
        ViewData["Text14"] = _localizer["Text14"];
        ViewData["Text15"] = _localizer["Text15"];
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(NewstellerPostDto dto)
    {
        try
        {
            ViewData["Text1"] = _localizer["Text1"];
            ViewData["Text2"] = _localizer["Text2"];
            ViewData["Text3"] = _localizer["Text3"];
            ViewData["Text4"] = _localizer["Text4"];
            ViewData["Text5"] = _localizer["Text5"];
            ViewData["Text6"] = _localizer["Text6"];
            ViewData["Text7"] = _localizer["Text7"];
            ViewData["Text8"] = _localizer["Text8"];
            ViewData["Text9"] = _localizer["Text9"];
            ViewData["Text10"] = _localizer["Text10"];
            ViewData["Text11"] = _localizer["Text11"];
            ViewData["Text12"] = _localizer["Text12"];
            ViewData["Text13"] = _localizer["Text13"];
            ViewData["Text14"] = _localizer["Text14"];
            ViewData["Text15"] = _localizer["Text15"];
            await _newstellerService.CreateNewstellerAsync(dto);
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            return RedirectToAction("Index", "Error");
        }
    }
}