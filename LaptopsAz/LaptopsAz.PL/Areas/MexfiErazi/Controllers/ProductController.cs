using AutoMapper;
using LaptopsAz.BL.DTOs.ProductDtos;
using LaptopsAz.BL.DTOs.ProductPhotoDtos;
using LaptopsAz.BL.DTOs.ProductSpecDtos;
using LaptopsAz.BL.ExternalServices.Abstractions;
using LaptopsAz.BL.Services.Abstractions;
using LaptopsAz.Core.Models;
using LaptopsAz.DL.Repositories.Abstractions;
using LaptopsAz.PL.Areas.MexfiErazi.ViewModels.ProductVMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LaptopsAz.PL.Areas.MexfiErazi.Controllers
{
    [Area("MexfiErazi")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IProductPhotoService _productPhotoService;
        private readonly IProductSpecService _productSpecService;
        private readonly IProductPhotoWriteRepository _productPhotoWriteRepository;
        private readonly IFileService _fileService;
        IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper, IProductService productService, ICategoryService categoryService, IProductPhotoWriteRepository productPhotoWriteRepository, IFileService fileService, IWebHostEnvironment webHostEnvironment, IProductPhotoService productPhotoService, IProductSpecService productSpecService)
        {
            _mapper = mapper;
            _productService = productService;
            _categoryService = categoryService;
            _productPhotoWriteRepository = productPhotoWriteRepository;
            _fileService = fileService;
            _webHostEnvironment = webHostEnvironment;
            _productPhotoService = productPhotoService;
            _productSpecService = productSpecService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                ICollection<ProductGetDto> products = await _productService.GetAllActiveProduct(10000);
                return View(products);
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

                ProductPostDto productPost = new ProductPostDto
                {
                    Categories = category,
                    Specs = new List<ProductSpecPostDto>
                    {
                        new ProductSpecPostDto()
                    }
                };

                return View(productPost);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductPostDto productPost)
        {
            if (!ModelState.IsValid)
            {
                var category = await _categoryService.SelectAllCategory();
                productPost.Categories = category;
                return View(productPost);
            }

            try
            {
                Product product = await _productService.CreateProductAsync(productPost);
                foreach (var item in productPost.Images)
                {
                    string itemName = await _fileService.SaveFileAsync(item, _webHostEnvironment.WebRootPath, new[] { ".png", ".jpg", ".jpeg" });
                    ProductPhoto productPhoto = new ProductPhoto()
                    {
                        PhotoURL = itemName,
                        ProductId = product.Id,
                        IsDeleted = false,
                        CreatedAt = DateTime.Now,
                    };
                    await _productPhotoWriteRepository.CreateAsync(productPhoto);
                    await _productPhotoWriteRepository.SaveChangesAsync();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                var category = await _categoryService.SelectAllCategory();
                productPost.Categories = category;
                return View(productPost);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            try
            {
                ProductGetDto productGetDto = await _productService.GetByIdProductAsync(id);
                ProductPutDto productPutDto = _mapper.Map<ProductPutDto>(productGetDto);
                var category = await _categoryService.SelectAllCategory();
                productPutDto.Categories = category;
                return View(productPutDto);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(ProductPutDto productPutDto)
        {
            try
            {
                await _productService.UpdateProductAsync(productPutDto);
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
                ICollection<ProductGetDto> productGetDto = await _productService.GetAllSoftDeletedProduct(10000);
                return View(productGetDto);
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
                ProductGetDto productGetDto = await _productService.GetByIdProductAsync(id);
                ICollection<ProductPhotoGetDto> productPhotoGetDtos = await _productPhotoService.GetAllProductPhoto(id);
                ICollection<ProductSpecGetDto> productSpecGetDtos = await _productSpecService.GetAllActiveProductSpec(id);
                DetailVm detailVm = new DetailVm()
                {
                    ProductGetDto = productGetDto,
                    ProductPhotoGetDtos = productPhotoGetDtos,
                    ProductSpecGetDtos = productSpecGetDtos,
                };
                return PartialView("_Detail", detailVm);

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
                await _productService.SoftDeleteProductAsync(id);
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
                await _productService.RestoreProductAsync(id);
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
                await _productService.DeleteProductAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }
    }
}
