using LaptopsAz.Core.Models;
using LaptopsAz.DL.Contexts;
using LaptopsAz.DL.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LaptopsAz.DL.Repositories.Implementations;

public class ProductSpecReadRepository : ReadRepository<ProductSpec>, IProductSpecReadRepository
{
    private readonly AppDbContext _context;
    public ProductSpecReadRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ICollection<SelectListItem>> SelectAllProductSpecAsync()
    {
        return await _context.ProductSpecs.Select(d => new SelectListItem
        {
            Value = d.Id.ToString(),
            Text = d.SpecName.ToString()
        }).ToListAsync();
    }
}