using System.Text;
using LaptopsAz.BL.DTOs.ProductDtos;
using LaptopsAz.BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace LaptopsAz.PL.Controllers;

public class SitemapController : Controller
{
    private readonly IProductService _productService;

    public SitemapController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("sitemap.xml")]
    public async Task<IActionResult> Index()
    {
        var baseUrl = $"{Request.Scheme}://{Request.Host}";

        var urls = new List<string>
        {
            $"{baseUrl}/",
            $"{baseUrl}/shop",
            $"{baseUrl}/productdetail",
            $"{baseUrl}/about",
            $"{baseUrl}/contact"
        };

        var products = await _productService.GetAllProducts();
        foreach (var product in products)
        {
            urls.Add($"{baseUrl}/productdetail/index/{product.Slug}");
        }

        var sitemapXml = GenerateSitemapXml(urls);
        return Content(sitemapXml, "application/xml");
    }

    private string GenerateSitemapXml(List<string> urls)
    {
        var sb = new StringBuilder();
        sb.AppendLine(@"<?xml version=""1.0"" encoding=""UTF-8""?>");
        sb.AppendLine(@"<urlset xmlns=""http://www.sitemaps.org/schemas/sitemap/0.9"">");

        foreach (var url in urls)
        {
            sb.AppendLine("  <url>");
            sb.AppendLine($"    <loc>{url}</loc>");
            sb.AppendLine($"    <lastmod>{DateTime.UtcNow:yyyy-MM-dd}</lastmod>");
            sb.AppendLine("    <changefreq>weekly</changefreq>");
            sb.AppendLine("    <priority>0.8</priority>");
            sb.AppendLine("  </url>");
        }

        sb.AppendLine("</urlset>");
        return sb.ToString();
    }
}