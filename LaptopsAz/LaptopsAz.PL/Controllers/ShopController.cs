// LaptopsAz.PL.Controllers/ShopController.cs

using LaptopsAz.BL.DTOs.ProductDtos;
using LaptopsAz.BL.DTOs.ProductSpecDtos;
using LaptopsAz.BL.Services.Abstractions;
using LaptopsAz.Core.Enums;
using LaptopsAz.Core.Models;
using LaptopsAz.DL.Contexts;
using LaptopsAz.DL.Repositories.Abstractions;
using LaptopsAz.PL.ViewModels.ShopVMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace LaptopsAz.PL.Controllers;

public class ShopController : Controller
{
    private readonly IProductService _productService;
    private readonly IProductSpecReadRepository _productSpecService;
    private readonly IProductReadRepository _productReadRepository;
    private readonly INewstellerService _newstellerService;
    private readonly IStringLocalizer<ShopController> _localizer;

    public ShopController(IProductService productService, IProductReadRepository productReadRepository, INewstellerService newstellerService, IProductSpecReadRepository productSpecService, IStringLocalizer<ShopController> localizer)
    {
        _productService = productService;
        _productReadRepository = productReadRepository;
        _newstellerService = newstellerService;
        _productSpecService = productSpecService;
        _localizer = localizer;
    }


    public async Task<IActionResult> Index(
    string? search = null,
    int page = 1,
    string viewMode = "grid",
    Guid? categoryId = null,
    decimal? minPrice = null, // YENİ ƏLAVƏ EDİLDİ
    decimal? maxPrice = null, // YENİ ƏLAVƏ EDİLDİ
    List<string>? SelectedProcessors = null,
    List<string>? SelectedRAMs = null,
    List<string>? SelectedGraphicsCards = null,
    List<string>? SelectedStorages = null,
    List<string>? SelectedMotherboards = null,
    List<string>? SelectedDisplays = null,
    List<string>? SelectedOperatingSystems = null
)
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
            ViewData["Text16"] = _localizer["Text16"];
            ViewData["Text17"] = _localizer["Text17"];
            ViewData["Text18"] = _localizer["Text18"];
            ViewData["Text19"] = _localizer["Text19"];
            ViewData["Text20"] = _localizer["Text20"];
            ViewData["Text21"] = _localizer["Text21"];
            ViewData["Text22"] = _localizer["Text22"];
            ViewData["Text23"] = _localizer["Text23"];
            ViewData["Text24"] = _localizer["Text24"];
            ViewData["Text25"] = _localizer["Text25"];
            ViewData["Text26"] = _localizer["Text26"];
            ViewData["Text27"] = _localizer["Text27"];
            ViewData["Text28"] = _localizer["Text28"];
            ViewData["Text29"] = _localizer["Text29"];
            ViewData["Text30"] = _localizer["Text30"];
            ViewData["Text31"] = _localizer["Text31"];
            ViewData["Text32"] = _localizer["Text32"];
            ViewData["Text33"] = _localizer["Text33"];
            ViewData["Text34"] = _localizer["Text34"];
            ViewData["Text35"] = _localizer["Text35"];
            ViewData["Text36"] = _localizer["Text36"];
            ViewData["Text37"] = _localizer["Text37"];
            ViewData["Text38"] = _localizer["Text38"];
            ViewData["Text39"] = _localizer["Text39"];
            ViewData["Text40"] = _localizer["Text40"];
            ViewData["Text41"] = _localizer["Text41"];
            ViewData["Text42"] = _localizer["Text42"];

            var activeProductIds = await _productReadRepository
                .GetAllByCondition(
                    condition: p => !p.IsDeleted &&
                                   (categoryId == null || p.CategoryID == categoryId) &&
                                   (search == null || p.ProductName.ToLower().Contains(search.ToLower())) &&
                                   (minPrice == null || p.DiscountPrice >= minPrice) && // YENİ ŞƏRT ƏLAVƏ EDİLDİ
                                   (maxPrice == null || p.DiscountPrice <= maxPrice),   // YENİ ŞƏRT ƏLAVƏ EDİLDİ
                    orderBy: q => q.OrderByDescending(p => p.CreatedAt))
                .Select(p => p.Id)
                .ToListAsync();

            if (!string.IsNullOrEmpty(search))
            {
                ViewData["CurrentSearch"] = search;
            }

            IQueryable<ProductSpec> specs = _productSpecService.GetAllByCondition(
                condition: p => !p.IsDeleted && activeProductIds.Contains(p.ProductID),
                orderBy: q => q.OrderByDescending(p => p.CreatedAt));

            var filteredProductIds = activeProductIds.AsEnumerable();

            if (SelectedProcessors != null && SelectedProcessors.Any())
            {
                var filteredByProcessor = specs
                    .Where(s => s.SpecName == ComputerSpecification.Processor && SelectedProcessors.Contains(s.SpecValue))
                    .Select(s => s.ProductID)
                    .Distinct()
                    .ToList();

                filteredProductIds = filteredProductIds.Intersect(filteredByProcessor);
            }

            if (SelectedRAMs != null && SelectedRAMs.Any())
            {
                var filteredByRAM = specs
                    .Where(s => s.SpecName == ComputerSpecification.RAM && SelectedRAMs.Contains(s.SpecValue))
                    .Select(s => s.ProductID)
                    .Distinct()
                    .ToList();

                filteredProductIds = filteredProductIds.Intersect(filteredByRAM);
            }

            if (SelectedGraphicsCards != null && SelectedGraphicsCards.Any())
            {
                var filteredByGC = specs
                    .Where(s => s.SpecName == ComputerSpecification.GraphicsCard && SelectedGraphicsCards.Contains(s.SpecValue))
                    .Select(s => s.ProductID)
                    .Distinct()
                    .ToList();

                filteredProductIds = filteredProductIds.Intersect(filteredByGC);
            }

            if (SelectedStorages != null && SelectedStorages.Any())
            {
                var filteredByStorage = specs
                    .Where(s => s.SpecName == ComputerSpecification.Storage && SelectedStorages.Contains(s.SpecValue))
                    .Select(s => s.ProductID)
                    .Distinct()
                    .ToList();

                filteredProductIds = filteredProductIds.Intersect(filteredByStorage);
            }

            if (SelectedMotherboards != null && SelectedMotherboards.Any())
            {
                var filteredByMB = specs
                    .Where(s => s.SpecName == ComputerSpecification.Motherboard && SelectedMotherboards.Contains(s.SpecValue))
                    .Select(s => s.ProductID)
                    .Distinct()
                    .ToList();

                filteredProductIds = filteredProductIds.Intersect(filteredByMB);
            }

            if (SelectedDisplays != null && SelectedDisplays.Any())
            {
                var filteredByDisplay = specs
                    .Where(s => s.SpecName == ComputerSpecification.Display && SelectedDisplays.Contains(s.SpecValue))
                    .Select(s => s.ProductID)
                    .Distinct()
                    .ToList();

                filteredProductIds = filteredProductIds.Intersect(filteredByDisplay);
            }

            if (SelectedOperatingSystems != null && SelectedOperatingSystems.Any())
            {
                var filteredByOS = specs
                    .Where(s => s.SpecName == ComputerSpecification.OperatingSystem && SelectedOperatingSystems.Contains(s.SpecValue))
                    .Select(s => s.ProductID)
                    .Distinct()
                    .ToList();

                filteredProductIds = filteredProductIds.Intersect(filteredByOS);
            }
            var filteredProductIdsList = filteredProductIds.ToList();
            var totalCount = filteredProductIdsList.Count();
            var productsList = await _productService.GetAllActiveProductByIds(filteredProductIdsList, 5, page - 1, categoryId);

            var productsGrid = await _productService.GetAllActiveProductByIds(filteredProductIdsList, 12, page - 1, categoryId);

            IQueryable<ProductSpec> specsForFilters = _productSpecService.GetAllByCondition(
                condition: p => !p.IsDeleted && filteredProductIdsList.Contains(p.ProductID),
                orderBy: q => q.OrderByDescending(p => p.CreatedAt));

            ShopFilterVM filters = new ShopFilterVM()
            {
                Processor = specsForFilters
                    .Where(s => s.SpecName == ComputerSpecification.Processor)
                    .Select(s => s.SpecValue)
                    .Distinct()
                    .ToList(),

                RAM = specsForFilters
                    .Where(s => s.SpecName == ComputerSpecification.RAM)
                    .Select(s => s.SpecValue)
                    .Distinct()
                    .ToList(),

                GraphicsCard = specsForFilters
                    .Where(s => s.SpecName == ComputerSpecification.GraphicsCard)
                    .Select(s => s.SpecValue)
                    .Distinct()
                    .ToList(),

                Storage = specsForFilters
                    .Where(s => s.SpecName == ComputerSpecification.Storage)
                    .Select(s => s.SpecValue)
                    .Distinct()
                    .ToList(),

                Motherboard = specsForFilters
                    .Where(s => s.SpecName == ComputerSpecification.Motherboard)
                    .Select(s => s.SpecValue)
                    .Distinct()
                    .ToList(),

                Display = specsForFilters
                    .Where(s => s.SpecName == ComputerSpecification.Display)
                    .Select(s => s.SpecValue)
                    .Distinct()
                    .ToList(),

                OperatingSystem = specsForFilters
                    .Where(s => s.SpecName == ComputerSpecification.OperatingSystem)
                    .Select(s => s.SpecValue)
                    .Distinct()
                    .ToList(),
            };

            ShopProductsVM shopProductsVm = new ShopProductsVM()
            {
                ProductsList = productsList,
                ProductsGrid = productsGrid,
                ShopFilterVM = filters,
                PageSizeForList = 5,
                PageSizeForGrid = 12,
                CurrentPageForGrid = page,
                CurrentPageForList = page,
                TotalCount = totalCount,
                ViewMode = viewMode,
                CurrentSearch = search,
                CurrentMinPrice = minPrice, // YENİ ƏLAVƏ EDİLDİ
                CurrentMaxPrice = maxPrice  // YENİ ƏLAVƏ EDİLDİ
            };

            return View(shopProductsVm);
        }
        catch (Exception e)
        {
            return RedirectToAction("Index", "Error");
        }
    }


    [HttpPost]
    public async Task<IActionResult> Index(ShopProductsVM shopProductsVM, int page = 0, Guid? categoryId = null)
    {
        try
        {
            await _newstellerService.CreateNewstellerAsync(shopProductsVM.NewstellerPostDto);
            
            ICollection<ProductGetDto> productsList = await _productService.GetAllActiveProduct(5, page, categoryId);
            ICollection<ProductGetDto> productsGrid = await _productService.GetAllActiveProduct(12, page, categoryId);
            var activeProductIds = await _productReadRepository.GetAllByCondition(
                condition: p => !p.IsDeleted,
                orderBy: q => q.OrderByDescending(p => p.CreatedAt))
                .Select(p => p.Id).ToListAsync();
            IQueryable<ProductSpec> specs = _productSpecService.GetAllByCondition(
                condition: p => !p.IsDeleted && activeProductIds.Contains(p.ProductID),
                orderBy: q => q.OrderByDescending(p => p.CreatedAt));

            ShopFilterVM filters = new ShopFilterVM()
            {
                Processor = specs.Where(s => s.SpecName == ComputerSpecification.Processor).Select(s => s.SpecValue).Distinct().ToList(),
                RAM = specs.Where(s => s.SpecName == ComputerSpecification.RAM).Select(s => s.SpecValue).Distinct().ToList(),
                GraphicsCard = specs.Where(s => s.SpecName == ComputerSpecification.GraphicsCard).Select(s => s.SpecValue).Distinct().ToList(),
                Storage = specs.Where(s => s.SpecName == ComputerSpecification.Storage).Select(s => s.SpecValue).Distinct().ToList(),
                Motherboard = specs.Where(s => s.SpecName == ComputerSpecification.Motherboard).Select(s => s.SpecValue).Distinct().ToList(),
                Display = specs.Where(s => s.SpecName == ComputerSpecification.Display).Select(s => s.SpecValue).Distinct().ToList(),
                OperatingSystem = specs.Where(s => s.SpecName == ComputerSpecification.OperatingSystem).Select(s => s.SpecValue).Distinct().ToList(),
            };
            
            shopProductsVM.ProductsList = productsList;
            shopProductsVM.ProductsGrid = productsGrid;
            shopProductsVM.ShopFilterVM = filters;

            return View(shopProductsVM);
        }
        catch (Exception e)
        {
            return RedirectToAction("Index", "Error");
        }
    }


    [HttpGet]
    public JsonResult LiveSearch(string searchTerm)
    {
        if (string.IsNullOrEmpty(searchTerm))
        {
            return Json(new List<object>());
        }

        var products = _productReadRepository.GetAllByCondition(
                condition: p => p.ProductName.Contains(searchTerm),
                orderBy: q => q.OrderByDescending(p => p.CreatedAt))
            .Select(p => new {
                id = p.Id,
                name = p.ProductName,
                imageUrl = p.ImageURL,
                price = p.DiscountPrice,
                slug = p.Slug,
            })
            .Take(10)
            .ToList();

        return Json(products);
    }
}