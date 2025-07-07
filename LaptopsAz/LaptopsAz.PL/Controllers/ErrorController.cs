using Microsoft.AspNetCore.Mvc;

namespace LaptopsAz.PL.Controllers;

public class ErrorController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}