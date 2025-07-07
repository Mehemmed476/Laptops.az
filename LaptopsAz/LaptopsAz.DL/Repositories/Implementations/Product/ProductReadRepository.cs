using LaptopsAz.Core.Models;
using LaptopsAz.DL.Contexts;
using LaptopsAz.DL.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LaptopsAz.DL.Repositories.Implementations;

public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
{
    private readonly AppDbContext _context;
    public ProductReadRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ICollection<SelectListItem>> SelectAllProductAsync()
    {
        return await _context.Products.Select(d => new SelectListItem
        {
            Value = d.Id.ToString(),
            Text = d.ProductName
        }).ToListAsync();
    }
}