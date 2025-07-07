using AutoMapper;
using LaptopsAz.BL.DTOs.BrandSliderDtos;
using LaptopsAz.BL.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LaptopsAz.PL.Areas.MexfiErazi.Controllers;
[Area("MexfiErazi")]
[Authorize]
public class BrandSliderController : Controller
{
    private readonly IBrandSliderService _brandSliderService;
    private readonly IMapper _mapper;

    public BrandSliderController(IMapper mapper, IBrandSliderService brandSliderService)
    {
        _mapper = mapper;
        _brandSliderService = brandSliderService;

    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        try
        {
            ICollection<BrandSliderGetDto> brandSliders = await _brandSliderService.GetAllActiveBrandSlider(10000);
            return View(brandSliders);
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
    public async Task<IActionResult> Create(BrandSliderPostDto brandSliderPost)
    {
        if (!ModelState.IsValid)
        {
            return View(brandSliderPost);
        }

        try
        {
            await _brandSliderService.CreateBrandSliderAsync(brandSliderPost);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View(brandSliderPost);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Update(Guid id)
    {
        try
        {
            BrandSliderGetDto brandSliderGetDto = await _brandSliderService.GetByIdBrandSliderAsync(id);
            BrandSliderPutDto brandSliderPutDto = _mapper.Map<BrandSliderPutDto>(brandSliderGetDto);
            return View(brandSliderPutDto);
        }
        catch (Exception ex)
        {
            return RedirectToAction("Index", "Error");
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(BrandSliderPutDto brandSliderPutDto)
    {
        try
        {
            await _brandSliderService.UpdateBrandSliderAsync(brandSliderPutDto);
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
            ICollection<BrandSliderGetDto> brandSliderGetDto = await _brandSliderService.GetAllSoftDeletedBrandSlider(10000);
            return View(brandSliderGetDto);
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

            BrandSliderGetDto brandSliderGetDto = await _brandSliderService.GetByIdBrandSliderAsync(id);
            return PartialView("_Detail", brandSliderGetDto);

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
            await _brandSliderService.SoftDeleteBrandSliderAsync(id);
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
            await _brandSliderService.RestoreBrandSliderAsync(id);
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
            await _brandSliderService.DeleteBrandSliderAsync(id);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            return RedirectToAction("Index", "Error");
        }
    }
}