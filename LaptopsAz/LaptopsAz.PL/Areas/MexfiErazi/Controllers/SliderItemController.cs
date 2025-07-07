using AutoMapper;
using LaptopsAz.BL.DTOs.SliderItemDtos;
using LaptopsAz.BL.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LaptopsAz.PL.Areas.MexfiErazi.Controllers;
[Area("MexfiErazi")]
[Authorize]
public class SliderItemController : Controller
{
    private readonly ISliderItemService _sliderItemService;
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public SliderItemController(IMapper mapper, ISliderItemService sliderItemService, ICategoryService categoryService)
    {
        _mapper = mapper;
        _sliderItemService = sliderItemService;
        _categoryService = categoryService;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        try
        {
            ICollection<SliderItemGetDto> sliderItems = await _sliderItemService.GetAllActiveSliderItem(10000);
            return View(sliderItems);
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
            var category = await _categoryService.SelectAllCategory();

            SliderItemPostDto sliderItemPost = new SliderItemPostDto
            {
                Categories = category
            };

            return View(sliderItemPost);
        }
        catch (Exception ex)
        {
            return RedirectToAction("Index", "Error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(SliderItemPostDto sliderItemPost)
    {
        if (!ModelState.IsValid)
        {
            var category = await _categoryService.SelectAllCategory();
            sliderItemPost.Categories = category;
            return View(sliderItemPost);
        }

        try
        {
            await _sliderItemService.CreateSliderItemAsync(sliderItemPost);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            var category = await _categoryService.SelectAllCategory();
            sliderItemPost.Categories = category;
            return View(sliderItemPost);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Update(Guid id)
    {
        try
        {
            SliderItemGetDto sliderItemGetDto = await _sliderItemService.GetByIdSliderItemAsync(id);
            SliderItemPutDto sliderItemPutDto = _mapper.Map<SliderItemPutDto>(sliderItemGetDto);
            var category = await _categoryService.SelectAllCategory();
            sliderItemPutDto.Categories = category;
            return View(sliderItemPutDto);
        }
        catch (Exception ex)
        {
            return RedirectToAction("Index", "Error");
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(SliderItemPutDto sliderItemPutDto)
    {
        try
        {
            await _sliderItemService.UpdateSliderItemAsync(sliderItemPutDto);
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
            ICollection<SliderItemGetDto> sliderItemGetDto = await _sliderItemService.GetAllSoftDeletedSliderItem(10000);
            return View(sliderItemGetDto);
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

            SliderItemGetDto sliderItemGetDto = await _sliderItemService.GetByIdSliderItemAsync(id);
            return PartialView("_Detail", sliderItemGetDto);

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
            await _sliderItemService.SoftDeleteSliderItemAsync(id);
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
            await _sliderItemService.RestoreSliderItemAsync(id);
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
            await _sliderItemService.DeleteSliderItemAsync(id);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            return RedirectToAction("Index", "Error");
        }
    }
}