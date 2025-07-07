using LaptopsAz.BL.DTOs.CategoryDtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaptopsAz.BL.Services.Abstractions;

public interface ICategoryService
{
    Task CreateCategoryAsync(CategoryPostDto dto);
    Task DeleteCategoryAsync(Guid id);
    Task SoftDeleteCategoryAsync(Guid id);
    Task RestoreCategoryAsync(Guid id);
    Task UpdateCategoryAsync(CategoryPutDto dto);
    Task<ICollection<CategoryGetDto>> GetAllActiveCategory(int size = 10, int page = 0);
    Task<ICollection<CategoryGetDto>> GetAllSoftDeletedCategory(int size = 10, int page = 0);
    Task<ICollection<CategoryGetDto>> GetTopCategoriesAsync();
    Task<CategoryGetDto> GetByIdCategoryAsync(Guid id);
    Task<ICollection<SelectListItem>> SelectAllCategory();
}