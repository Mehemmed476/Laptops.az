using AutoMapper;
using LaptopsAz.BL.DTOs.CategoryDtos;
using LaptopsAz.BL.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LaptopsAz.PL.Areas.MexfiErazi.Controllers
{
    [Area("MexfiErazi")]
    [Authorize]
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                ICollection<CategoryGetDto> categories = await _categoryService.GetAllActiveCategory(10000);                           
                return View(categories);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryPostDto categoryPostDto)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryPostDto);
            }
            try
            {
                await _categoryService.CreateCategoryAsync(categoryPostDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            try
            {
                CategoryGetDto categoryGetDto = await _categoryService.GetByIdCategoryAsync(id);
                Console.WriteLine("getDto.ImageUrl: " + categoryGetDto.ImageURL);
                CategoryPutDto categoryPutDto = _mapper.Map<CategoryPutDto>(categoryGetDto);
                
                Console.WriteLine("putDto.ImageUrl: " + categoryPutDto.ImageURL);
                return View(categoryPutDto);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryPutDto categoryPutDto)
        {
            try
            {
                await _categoryService.UpdateCategoryAsync(categoryPutDto);
                return RedirectToAction("Index");
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
                await _categoryService.SoftDeleteCategoryAsync(id);
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
                await _categoryService.RestoreCategoryAsync(id);
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
                await _categoryService.DeleteCategoryAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["CategoryDeleteError"] = "Bu kateqoriyaya aid məhsullar olduğu üçün silmək mümkün deyil.";
                return RedirectToAction("Index", "Category");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Trash()
        {
            try
            {
                ICollection<CategoryGetDto> categories = await _categoryService.GetAllSoftDeletedCategory(10000);
                return View(categories);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }

        }
    }
}
