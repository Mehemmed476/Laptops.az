using Microsoft.AspNetCore.Mvc;

namespace LaptopsAz.PL.Controllers;

public class RobotsController : Controller
{
    [HttpGet("robots.txt")]
    public IActionResult Index()
    {
        var content = @"User-agent: *
Disallow: /admin/
Disallow: /cart/
Disallow: /checkout/

Sitemap: https://www.laptops.az/sitemap.xml";

        return Content(content, "text/plain");
    }
}