using LaptopsAz.BL.Helpers;
using LaptopsAz.DL.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaptopsAz.PL.Controllers;

public class TestController : Controller
{

    private readonly AppDbContext _context;

    public TestController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> GenerateAllSlugs()
    {
        var products = await _context.Products.ToListAsync();
        int updatedCount = 0;

        foreach (var product in products)
        {
            if (string.IsNullOrEmpty(product.Slug))
            {
                product.Slug = SlugHelper.GenerateSlug(product.ProductName);
                _context.Update(product);
                updatedCount++;
            }
        }

        if (updatedCount > 0)
        {
            await _context.SaveChangesAsync();
        }

        return Ok($"{updatedCount} adet ürünün slug'ı başarıyla oluşturuldu/güncellendi.");
    }
}