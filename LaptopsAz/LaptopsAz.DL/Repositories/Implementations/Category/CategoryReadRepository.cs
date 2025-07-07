using LaptopsAz.Core.Models;
using LaptopsAz.DL.Contexts;
using LaptopsAz.DL.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LaptopsAz.DL.Repositories.Implementations;

public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
{
    private readonly AppDbContext _context;
    public CategoryReadRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ICollection<SelectListItem>> SelectAllCategoryAsync()
    {
        return await _context.Categories.Select(d => new SelectListItem
        {
            Value = d.Id.ToString(),
            Text = d.CategoryName
        }).ToListAsync();
    }
}