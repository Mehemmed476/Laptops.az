using System.Collections;
using System.Text.RegularExpressions;
using LaptopsAz.BL.DTOs.BrandSliderDtos;
using LaptopsAz.BL.DTOs.CategoryDtos;
using LaptopsAz.BL.DTOs.ProductDtos;
using LaptopsAz.BL.DTOs.ShortVideoDtos;
using LaptopsAz.BL.DTOs.SliderItemDtos;
using LaptopsAz.BL.Services.Abstractions;
using LaptopsAz.Core.Models;
using LaptopsAz.PL.ViewModels.HomeVMs;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.Extensions.Localization;
namespace LaptopsAz.PL.Controllers;

public class HomeController : Controller
{
    private readonly ISliderItemService _sliderItemService;
    private readonly IBrandSliderService _brandSliderService;
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly INewstellerService _newstellerService;
    private readonly IShortVideoService _shortVideoService;
    private readonly IStringLocalizer<HomeController> _localizer;

    public HomeController(ISliderItemService sliderItemService, IBrandSliderService brandSliderService, IProductService productService, ICategoryService categoryService, INewstellerService newstellerService, IStringLocalizer<HomeController> localizer, IShortVideoService shortVideoService)
    {
        _sliderItemService = sliderItemService;
        _brandSliderService = brandSliderService;
        _productService = productService;
        _categoryService = categoryService;
        _newstellerService = newstellerService;
        _localizer = localizer;
        _shortVideoService = shortVideoService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        try
        {
            var userAgent = HttpContext.Request.Headers["User-Agent"].ToString();

            bool isPhone = Regex.IsMatch(userAgent, @"(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|rim)|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline);

            bool isTablet = Regex.IsMatch(userAgent, @"android|ipad|playbook|silk|tablet", RegexOptions.IgnoreCase);

            if (isPhone || isTablet)
            {
                return RedirectToAction("Index", "Shop");
            }

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
            ViewData["Text43"] = _localizer["Text43"];
            ViewData["Text44"] = _localizer["Text44"];
            
            ICollection<SliderItemGetDto> sliderItems = await _sliderItemService.GetAllActiveSliderItem();
            ICollection<BrandSliderGetDto> brandSliders = await _brandSliderService.GetAllActiveBrandSlider();
            ICollection<CategoryGetDto> categories = await _categoryService.GetTopCategoriesAsync();
            ICollection<ProductGetDto> products = await _productService.GetAllActiveProduct();
            ICollection<ProductGetDto> newProducts = await _productService.GetLatestProducts(6);
            ICollection<ProductGetDto> ourProducts = await _productService.GetOurProducts(10);
            ICollection<ProductGetDto> newestProducts = await _productService.GetNewestProducts(10);
            ICollection<ProductGetDto> hotDeals = await _productService.GetHotDeals(10);
            ICollection<ProductGetDto> bestSellers  = await _productService.GetBestSellers(10);
            ICollection<ShortVideoGetDto> shorts = await _shortVideoService.GetAllActiveShortVideo();
            HomeVM homeVm = new HomeVM()
            {
                SliderItems = sliderItems,
                BrandSliders = brandSliders,
                Categories = categories,
                Products = products,
                NewProducts = newProducts,
                BestSellers = bestSellers,
                OurProducts = ourProducts,
                NewestProducts = newestProducts,
                HotDeals = hotDeals,
                Shorts = shorts,
            };
            return View(homeVm);
        }
        catch (Exception e)
        {
            return RedirectToAction("Index", "Error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Index(HomeVM homeVm)
    {
        try
        {
            await _newstellerService.CreateNewstellerAsync(homeVm.NewstellerPostDto);
            
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
            ViewData["Text43"] = _localizer["Text43"];
            ViewData["Text44"] = _localizer["Text44"];
            
            ICollection<SliderItemGetDto> sliderItems = await _sliderItemService.GetAllActiveSliderItem();
            ICollection<BrandSliderGetDto> brandSliders = await _brandSliderService.GetAllActiveBrandSlider();
            ICollection<CategoryGetDto> categories = await _categoryService.GetTopCategoriesAsync();
            ICollection<ProductGetDto> products = await _productService.GetAllActiveProduct();
            ICollection<ProductGetDto> newProducts = await _productService.GetLatestProducts(6);
            ICollection<ProductGetDto> ourProducts = await _productService.GetOurProducts(10);
            ICollection<ProductGetDto> newestProducts = await _productService.GetNewestProducts(10);
            ICollection<ProductGetDto> hotDeals = await _productService.GetHotDeals(10);
            ICollection<ProductGetDto> bestSellers  = await _productService.GetBestSellers(10);
            ICollection<ShortVideoGetDto> shorts = await _shortVideoService.GetAllActiveShortVideo();

            homeVm.SliderItems = sliderItems;
            homeVm.BrandSliders = brandSliders;
            homeVm.Categories = categories;
            homeVm.Products = products;
            homeVm.NewProducts = newProducts;
            homeVm.NewestProducts = newestProducts;
            homeVm.HotDeals = hotDeals;
            homeVm.BestSellers = bestSellers;
            homeVm.OurProducts = ourProducts;
            homeVm.Shorts = shorts;
            return View(homeVm);
        }
        catch (Exception e)
        {
            return RedirectToAction("Index", "Error");
        }
    }
    [HttpPost]
    public IActionResult SetLanguage(string culture)
    {
        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1),
                IsEssential = true
            }
        );

        return Redirect(Request.Headers["Referer"].ToString());
    }
    
}