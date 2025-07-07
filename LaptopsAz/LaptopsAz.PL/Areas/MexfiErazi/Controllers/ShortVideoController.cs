using AutoMapper;
using LaptopsAz.BL.DTOs.ShortVideoDtos;
using LaptopsAz.BL.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LaptopsAz.PL.Areas.MexfiErazi.Controllers;
[Area("MexfiErazi")]
[Authorize]
public class ShortVideoController : Controller
{
    private readonly IShortVideoService _shortVideoService;
    private readonly IMapper _mapper;

    public ShortVideoController(IMapper mapper, IShortVideoService shortVideoService)
    {
        _mapper = mapper;
        _shortVideoService = shortVideoService;

    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        try
        {
            ICollection<ShortVideoGetDto> shortVideos = await _shortVideoService.GetAllActiveShortVideo(10000);
            return View(shortVideos);
        }
        catch (Exception ex)
        {
            return RedirectToAction("Index", "Error");
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        try
        {
            return View();
        }
        catch (Exception ex)
        {
            return RedirectToAction("Index", "Error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(ShortVideoPostDto shortVideoPost)
    {
        if (!ModelState.IsValid)
        {
            return View(shortVideoPost);
        }

        try
        {
            await _shortVideoService.CreateShortVideoAsync(shortVideoPost);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View(shortVideoPost);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Update(Guid id)
    {
        try
        {
            ShortVideoGetDto shortVideoGetDto = await _shortVideoService.GetByIdShortVideoAsync(id);
            ShortVideoPutDto shortVideoPutDto = _mapper.Map<ShortVideoPutDto>(shortVideoGetDto);
            return View(shortVideoPutDto);
        }
        catch (Exception ex)
        {
            return RedirectToAction("Index", "Error");
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(ShortVideoPutDto shortVideoPutDto)
    {
        try
        {
            await _shortVideoService.UpdateShortVideoAsync(shortVideoPutDto);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            return RedirectToAction("Index", "Error");
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> Trash()
    {
        try
        {
            ICollection<ShortVideoGetDto> shortVideoGetDto = await _shortVideoService.GetAllSoftDeletedShortVideo(10000);
            return View(shortVideoGetDto);
        }
        catch (Exception ex)
        {
            return RedirectToAction("Index", "Error");
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> Detail(Guid id)
    {
        try
        {

            ShortVideoGetDto shortVideoGetDto = await _shortVideoService.GetByIdShortVideoAsync(id);
            return PartialView("_Detail", shortVideoGetDto);

        }
        catch (Exception ex)
        {
            return RedirectToAction("Index", "Error");
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> SoftDelete(Guid id)
    {
        try
        {
            await _shortVideoService.SoftDeleteShortVideoAsync(id);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            return RedirectToAction("Index", "Error");
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> Restore(Guid id)
    {
        try
        {
            await _shortVideoService.RestoreShortVideoAsync(id);
            return RedirectToAction("Trash");
        }
        catch (Exception ex)
        {
            return RedirectToAction("Index", "Error");
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _shortVideoService.DeleteShortVideoAsync(id);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            return RedirectToAction("Index", "Error");
        }
    }
}