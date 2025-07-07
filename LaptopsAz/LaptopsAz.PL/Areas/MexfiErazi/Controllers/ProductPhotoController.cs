using AutoMapper;
using LaptopsAz.BL.DTOs.ProductPhotoDtos;
using LaptopsAz.BL.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LaptopsAz.PL.Areas.MexfiErazi.Controllers;
[Area("MexfiErazi")]
[Authorize]
public class ProductPhotoController : Controller
{
    private readonly IProductPhotoService _productPhotoService;
    private readonly IMapper _mapper;
    
    public ProductPhotoController(IProductPhotoService productPhotoService, IMapper mapper)
    {
        _productPhotoService = productPhotoService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Update(Guid id)
    {
        try
        {
            ProductPhotoGetDto productPhotoGetDto = await _productPhotoService.GetByIdProductPhotoAsync(id);
            ProductPhotoPutDto productPhotoPutDto = _mapper.Map<ProductPhotoPutDto>(productPhotoGetDto);
            return View(productPhotoPutDto);
        }
        catch (Exception e)
        {
            return RedirectToAction("Index", "Error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Update(ProductPhotoPutDto productPhotoPutDto)
    {
        try
        {
            await _productPhotoService.UpdateProductPhotoAsync(productPhotoPutDto);
            return RedirectToAction("Index", "Product");
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
            await _productPhotoService.DeleteProductPhotoAsync(id);
            return RedirectToAction("Index", "Product");
        }
        catch (Exception e)
        {
            return RedirectToAction("Index", "Error");
        }
    }
}