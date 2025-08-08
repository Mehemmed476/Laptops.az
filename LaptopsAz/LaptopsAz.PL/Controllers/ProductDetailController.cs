using AutoMapper;
using LaptopsAz.BL.DTOs.ProductDtos;
using LaptopsAz.BL.DTOs.ProductPhotoDtos;
using LaptopsAz.BL.DTOs.ProductSpecDtos;
using LaptopsAz.BL.DTOs.ReviewDtos;
using LaptopsAz.BL.Services.Abstractions;
using LaptopsAz.PL.ViewModels.ShopVMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace LaptopsAz.PL.Controllers;

public class ProductDetailController : Controller
{
    private readonly IProductService _productService;
    private readonly IProductSpecService _productSpecService;
    private readonly IProductPhotoService _productPhotoService;
    private readonly IReviewService _reviewService;
    private readonly INewstellerService _newstellerService;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<ProductDetailController> _localizer;
    
    public ProductDetailController(IProductService productService, IProductSpecService productSpecService, IMapper mapper, IProductPhotoService productPhotoService, IReviewService reviewService, IStringLocalizer<ProductDetailController> localizer, INewstellerService newstellerService)
    {
        _productService = productService;
        _productSpecService = productSpecService;
        _mapper = mapper;
        _productPhotoService = productPhotoService;
        _reviewService = reviewService;
        _localizer = localizer;
        _newstellerService = newstellerService;
    }
    
    public async Task<IActionResult> Index(string slug)
    {
        try
        {
            ViewData["Text1"] = _localizer["Text1"];
            ViewData["Text10"] = _localizer["Text10"];
            ViewData["Text11"] = _localizer["Text11"];
            ViewData["Text12"] = _localizer["Text12"];
            ViewData["Text13"] = _localizer["Text13"];
            ViewData["Text14"] = _localizer["Text14"];
            ViewData["Text15"] = _localizer["Text15"];
            ViewData["Text16"] = _localizer["Text16"];
            ViewData["Text17"] = _localizer["Text17"];
            
            ProductGetDto product = await _productService.GetBySlugAsync(slug);
            ICollection<ProductSpecGetDto> specs = await _productSpecService.GetByProductIdProductSpecsAsync(product.Id);
            ICollection<ReviewGetDto> reviews = await _reviewService.GetByProductIdReviewsAsync(product.Id);
            ICollection<ProductPhotoGetDto> photos = await _productPhotoService.GetByProductIdProductPhotosAsync(product.Id);
            ICollection<ProductGetDto> latestProducts = await _productService.GetLatestProducts(5);
            
            ProductDetailVM productVm = new ProductDetailVM()
            {
                Product = product,
                ProductSpecs = specs,
                Reviews = reviews,
                Photos = photos,
                LatestProducts = latestProducts,
            };
            return View(productVm);
        }
        catch (Exception e)
        {
            return RedirectToAction("Index", "Error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Index(ProductDetailVM productDetailVm, string slug)
    {
        try
        {
            ViewData["Text1"] = _localizer["Text1"];
            ViewData["Text10"] = _localizer["Text10"];
            ViewData["Text11"] = _localizer["Text11"];
            ViewData["Text12"] = _localizer["Text12"];
            ViewData["Text13"] = _localizer["Text13"];
            ViewData["Text14"] = _localizer["Text14"];
            ViewData["Text15"] = _localizer["Text15"];
            ViewData["Text16"] = _localizer["Text16"];
            ViewData["Text17"] = _localizer["Text17"];

            
            
            ProductGetDto product = await _productService.GetBySlugAsync(slug);
            ICollection<ProductSpecGetDto> specs = await _productSpecService.GetByProductIdProductSpecsAsync(product.Id);
            ICollection<ReviewGetDto> reviews = await _reviewService.GetByProductIdReviewsAsync(product.Id);
            ICollection<ProductPhotoGetDto> photos = await _productPhotoService.GetByProductIdProductPhotosAsync(product.Id);
            ICollection<ProductGetDto> latestProducts = await _productService.GetLatestProducts(5);
            
            if (productDetailVm.ReviewPost is not null)
            {
                productDetailVm.ReviewPost.ProductID = product.Id;
                await _reviewService.CreateReviewAsync(productDetailVm.ReviewPost);
            }
            
            if (productDetailVm.NewstellerPostDto is not null)
            {
                await _newstellerService.CreateNewstellerAsync(productDetailVm.NewstellerPostDto);
            }
            
            productDetailVm.Product = product;
            productDetailVm.ProductSpecs = specs;
            productDetailVm.Reviews = reviews;
            productDetailVm.Photos = photos;
            productDetailVm.LatestProducts = latestProducts;
            
            return View(productDetailVm);
        }
        catch (Exception e)
        {
            return RedirectToAction("Index", "Error");
        }
    }
}