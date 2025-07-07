using AutoMapper;
using LaptopsAz.BL.DTOs.CategoryDtos;
using LaptopsAz.BL.ExternalServices.Abstractions;
using LaptopsAz.BL.Services.Abstractions;
using LaptopsAz.Core.Models;
using LaptopsAz.DL.Repositories.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LaptopsAz.BL.Services.Implementations;

public class CategoryService : ICategoryService
{
    private readonly ICategoryReadRepository _categoryReadRepository;
    private readonly ICategoryWriteRepository _categoryWriteRepository;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;
    IWebHostEnvironment _webHostEnvironment;
    
    public CategoryService(ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository, IMapper mapper, IFileService fileService, IWebHostEnvironment webHostEnvironment)
    {
        _categoryReadRepository = categoryReadRepository;
        _categoryWriteRepository = categoryWriteRepository;
        _mapper = mapper;
        _fileService = fileService;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task CreateCategoryAsync(CategoryPostDto categoryPostDto)
    {
        Category category = _mapper.Map<Category>(categoryPostDto);
        category.CreatedAt = DateTime.UtcNow.AddHours(4);
        category.ImageURL = await _fileService.SaveFileAsync(categoryPostDto.Image, _webHostEnvironment.WebRootPath,new[] { ".png", ".jpg", ".jpeg" } );
        await _categoryWriteRepository.CreateAsync(category);
        var result = await _categoryWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("Category not created");
        }
    }

    public async Task DeleteCategoryAsync(Guid id)
    {
        if (!await _categoryReadRepository.IsExist(id)) throw new Exception("Category not found");
        Category category = await _categoryReadRepository.GetByIdAsync(id) ?? throw new Exception("Category not found");
        _categoryWriteRepository.Delete(category);
        
        var result = await _categoryWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("Category not created");
        }
        
    }

    public async Task<ICollection<CategoryGetDto>> GetAllActiveCategory(int size = 10, int page = 0)
    {
        ICollection<Category> categorys = await _categoryReadRepository.GetAllByCondition(c => !c.IsDeleted, page, size).ToListAsync();
        return _mapper.Map<ICollection<CategoryGetDto>>(categorys);
    }

    public async Task<ICollection<CategoryGetDto>> GetAllSoftDeletedCategory(int size = 10, int page = 0)
    {
        ICollection<Category> categorys = await _categoryReadRepository.GetAllByCondition(c => c.IsDeleted, page, size).ToListAsync();
        return _mapper.Map<ICollection<CategoryGetDto>>(categorys);
    }

    public async Task<ICollection<CategoryGetDto>> GetTopCategoriesAsync()
    {
        ICollection<Category> categorys = await _categoryReadRepository.GetAllByCondition(c => !c.IsDeleted && c.IsTop).Take(10).ToListAsync();
        return _mapper.Map<ICollection<CategoryGetDto>>(categorys);
    }

    public async Task<CategoryGetDto> GetByIdCategoryAsync(Guid id)
    {
        if (!await _categoryReadRepository.IsExist(id)) throw new Exception("Category not found");
        Category category = await _categoryReadRepository.GetByIdAsync(id) ?? throw new Exception("Category not found");
        return _mapper.Map<CategoryGetDto>(category);
    }

    public async Task RestoreCategoryAsync(Guid id)
    {
        if (!await _categoryReadRepository.IsExist(id)) throw new Exception("Category not found");
        Category category = await _categoryReadRepository.GetOneByCondition(c => c.Id == id && c.IsDeleted, false) ?? throw new Exception("Category not found");
        category.IsDeleted = false;
        _categoryWriteRepository.Update(category);

        var result = await _categoryWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("Category not created");
        }
    }

    public async Task SoftDeleteCategoryAsync(Guid id)
    {
        if (!await _categoryReadRepository.IsExist(id)) throw new Exception("Category not found");
        Category category = await _categoryReadRepository.GetOneByCondition(c => c.Id == id && !c.IsDeleted, false) ?? throw new Exception("Category not found");
        category.IsDeleted = true;
        _categoryWriteRepository.Update(category);

        var result = await _categoryWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("Category not created");
        }
    }

    public async Task UpdateCategoryAsync(CategoryPutDto categoryPutDto)
    {
        Category oldCategory = await _categoryReadRepository.GetByIdAsync(categoryPutDto.Id, false);
        Category category = _mapper.Map<Category>(categoryPutDto);
        if (categoryPutDto.Image != null && categoryPutDto.Image.Length > 0)
        {
            category.ImageURL = await _fileService.SaveFileAsync(
                categoryPutDto.Image,
                _webHostEnvironment.WebRootPath,
                new[] { ".png", ".jpg", ".jpeg" });
        }
        else
        {
            category.ImageURL = oldCategory.ImageURL;
        }
        category.CreatedAt = oldCategory.CreatedAt;
        _categoryWriteRepository.Update(category);
    
        var result = await _categoryWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("Category not created");
        }
    }
    
    public async Task<ICollection<SelectListItem>> SelectAllCategory()
    {
        return await _categoryReadRepository.SelectAllCategoryAsync();
    }
}