using LaptopsAz.BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace LaptopsAz.PL.ViewComponents;

public class CategoryViewComponent : ViewComponent
{
    private readonly ICategoryService _categoryService;

    public CategoryViewComponent(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var categories = await _categoryService.GetAllActiveCategory();
        return View(categories); 
    }
}