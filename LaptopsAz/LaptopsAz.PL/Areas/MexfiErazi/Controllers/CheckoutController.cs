using AutoMapper;
using LaptopsAz.BL.DTOs.CheckoutDtos;
using LaptopsAz.BL.Services.Abstractions;
using LaptopsAz.BL.Services.Implementations;
using LaptopsAz.DL.Repositories.Abstractions;
using LaptopsAz.DL.Repositories.Implementations;
using LaptopsAz.PL.Areas.MexfiErazi.ViewModels.CheckoutVMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaptopsAz.PL.Areas.MexfiErazi.Controllers;
[Area("MexfiErazi")]
[Authorize]
public class CheckoutController : Controller
{
    private readonly ICheckoutService _checkoutService;
    private readonly IProductReadRepository _productReadRepository;
    private readonly IMapper _mapper;

    public CheckoutController(IMapper mapper, ICheckoutService checkoutService, IProductReadRepository productReadRepository)
    {
        _mapper = mapper;
        _checkoutService = checkoutService;
        _productReadRepository = productReadRepository;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        try
        {
            ICollection<CheckoutGetDto> checkouts = await _checkoutService.GetAllActiveCheckout(10000);
            var viewModels = new List<CheckoutWithProductsVM>();
            foreach (var checkout in checkouts)
            {
                var productIds = checkout.ProductIds?
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(id => Guid.Parse(id))
                    .ToList() ?? new List<Guid>();

                var products = await _productReadRepository
                    .GetAllByCondition(p => productIds.Contains(p.Id), null)
                    .ToListAsync();
                viewModels.Add(new CheckoutWithProductsVM
                {
                    Id = checkout.Id,
                    FirstName = checkout.FirstName,
                    LastName = checkout.LastName,
                    Email = checkout.Email,
                    Address = checkout.City + " ," + checkout.StreetAddress + " ," + checkout.ApartmentNumber,
                    Phone = checkout.Phone,
                    Notes = checkout.Notes,
                    ProductNames = products.Select(p => p.ProductName).ToList()
                });
            }
            return View(viewModels);
        }
        catch (Exception ex)
        {
            return RedirectToAction("Index", "Error");
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> Finished()
    {
        try
        {
            ICollection<CheckoutGetDto> checkouts = await _checkoutService.GetAllSoftDeletedCheckout(10000);
            var viewModels = new List<CheckoutWithProductsVM>();
            foreach (var checkout in checkouts)
            {
                var productIds = checkout.ProductIds?
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(id => Guid.Parse(id))
                    .ToList() ?? new List<Guid>();

                var products = await _productReadRepository
                    .GetAllByCondition(p => productIds.Contains(p.Id), null)
                    .ToListAsync();
                viewModels.Add(new CheckoutWithProductsVM
                {
                    Id = checkout.Id,
                    FirstName = checkout.FirstName,
                    LastName = checkout.LastName,
                    Email = checkout.Email,
                    Address = checkout.City + " ," + checkout.StreetAddress + " ," + checkout.ApartmentNumber,
                    Phone = checkout.Phone,
                    Notes = checkout.Notes,
                    ProductNames = products.Select(p => p.ProductName).ToList()
                });
            }
            return View(viewModels);
        }
        catch (Exception ex)
        {
            return RedirectToAction("Index", "Error");
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> FinishTag(Guid id)
    {
        try
        {
            await _checkoutService.SoftDeleteCheckoutAsync(id);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            return RedirectToAction("Index", "Error");
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> DeleteFinishTag(Guid id)
    {
        try
        {
            await _checkoutService.RestoreCheckoutAsync(id);
            return RedirectToAction("Finished");
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
            await _checkoutService.DeleteCheckoutAsync(id);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            return RedirectToAction("Index", "Error");
        }
    }
}