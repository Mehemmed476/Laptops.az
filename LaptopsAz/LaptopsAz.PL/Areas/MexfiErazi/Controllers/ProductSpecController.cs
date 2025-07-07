using AutoMapper;
using LaptopsAz.BL.DTOs.ProductSpecDtos;
using LaptopsAz.BL.Services.Abstractions;
using LaptopsAz.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaptopsAz.PL.Areas.MexfiErazi.Controllers;
[Area("MexfiErazi")]
[Authorize]
public class ProductSpecController : Controller
{
    private readonly IProductSpecService _productSpecService;
    private readonly IMapper _mapper;
    
    public ProductSpecController(IProductSpecService productSpecService, IMapper mapper)
    {
        _productSpecService = productSpecService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Update(Guid id)
    {
        try
        {
            ProductSpecGetDto productSpecGetDto = await _productSpecService.GetByIdProductSpecAsync(id);
            ProductSpecPutDto productSpecPutDto = _mapper.Map<ProductSpecPutDto>(productSpecGetDto);
            productSpecPutDto.AllSpecNames = Enum.GetNames(typeof(ComputerSpecification)) 
                .Select(name => new SelectListItem
                {
                    Value = name,
                    Text = name
                }).ToList();
            
            return View(productSpecPutDto);
        }
        catch (Exception e)
        {
            return RedirectToAction("Index", "Error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Update(ProductSpecPutDto productSpecPutDto)
    {
        if (!ModelState.IsValid)
        {
            productSpecPutDto.AllSpecNames = Enum.GetNames(typeof(ComputerSpecification)) 
                .Select(name => new SelectListItem
                {
                    Value = name,
                    Text = name
                }).ToList();
            
            return View(productSpecPutDto);
        }
        try
        {
            await _productSpecService.UpdateProductSpecAsync(productSpecPutDto);
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
            await _productSpecService.DeleteProductSpecAsync(id);
            return RedirectToAction("Index", "Product");
        }
        catch (Exception e)
        {
            return RedirectToAction("Index", "Error");
        }
    }
}