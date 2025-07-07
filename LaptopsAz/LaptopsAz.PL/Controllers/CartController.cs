using System.Text.Json;
using LaptopsAz.BL.Services.Abstractions;
using LaptopsAz.Core.Models;
using LaptopsAz.DL.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace LaptopsAz.PL.Controllers;

public class CartController : Controller
{
    private const string CartCookieKey = "cart";
    
    private readonly IProductService _productService;
    private readonly ICheckoutWriteRepository _checkoutWriteRepository;
    private readonly IStringLocalizer<CartController> _localizer;
    public CartController(IProductService productService, ICheckoutWriteRepository checkoutWriteRepository, IStringLocalizer<CartController> localizer)
    {
        _productService = productService;
        _checkoutWriteRepository = checkoutWriteRepository;
        _localizer = localizer;
    }

    // Cookie'den sepeti oxumaq
    private List<CartItem> GetCartItems()
    {
        var cartJson = Request.Cookies[CartCookieKey];
        if (string.IsNullOrEmpty(cartJson))
        {
            return new List<CartItem>();
        }

        return JsonSerializer.Deserialize<List<CartItem>>(cartJson);
    }

    // Cookie'ye sepeti yazmaq
    private void SaveCartItems(List<CartItem> items)
    {
        var options = new CookieOptions
        {
            Expires = DateTimeOffset.Now.AddDays(7),
            HttpOnly = true
        };

        var cartJson = JsonSerializer.Serialize(items);
        Response.Cookies.Append(CartCookieKey, cartJson, options);
    }

    // Sepeti göstər (GET /Cart)
    [HttpGet]
    public IActionResult Index()
    {
        ViewData["Text1"] = _localizer["Text1"];
        ViewData["Text2"] = _localizer["Text2"];
        ViewData["Text3"] = _localizer["Text3"];
        ViewData["Text4"] = _localizer["Text4"];
        ViewData["Text5"] = _localizer["Text5"];
        ViewData["Text6"] = _localizer["Text6"];
        ViewData["Text7"] = _localizer["Text7"];
        ViewData["Text8"] = _localizer["Text8"];
        ViewData["Text9"] = _localizer["Text9"];
        ViewData["Text10"] = _localizer["Text10"];
        ViewData["Text11"] = _localizer["Text11"];
        ViewData["Text12"] = _localizer["Text12"];
        ViewData["Text13"] = _localizer["Text13"];
        ViewData["Text14"] = _localizer["Text14"];
        ViewData["Text15"] = _localizer["Text15"];
        ViewData["Text16"] = _localizer["Text16"];
        ViewData["Text17"] = _localizer["Text17"];
        ViewData["Text18"] = _localizer["Text18"];
        ViewData["Text19"] = _localizer["Text19"];
        var cartItems = GetCartItems();
        return View(cartItems);
    }

    [HttpGet]
    public async Task<IActionResult> AddToCart(Guid id)
    {
        var cartItems = GetCartItems();
        var product = await _productService.GetByIdProductAsync(id);

        var existingItem = cartItems.FirstOrDefault(x => x.ProductID == id);

        if (existingItem != null)
        {
            existingItem.Quantity += 1; 
        }
        else
        {
            cartItems.Add(new CartItem
            {
                ProductID = product.Id,
                ProductName = product.ProductName,
                ImageURL = product.ImageURL,
                Price = product.DiscountPrice,
                Quantity = 1
            });
        }

        SaveCartItems(cartItems);
        return RedirectToAction("Index");
    }

    
    [HttpGet]
    public IActionResult RemoveFromCart(Guid productId)
    {
        var cartItems = GetCartItems();
        var itemToRemove = cartItems.FirstOrDefault(x => x.ProductID == productId);

        if (itemToRemove != null)
        {
            cartItems.Remove(itemToRemove);
            SaveCartItems(cartItems);
        }

        return RedirectToAction("Index");
    }

    
    [HttpGet]
    public IActionResult Checkout()
    {
        ViewData["Text1"] = _localizer["Text1"];
        ViewData["Text2"] = _localizer["Text2"];
        ViewData["Text3"] = _localizer["Text3"];
        ViewData["Text4"] = _localizer["Text4"];
        ViewData["Text5"] = _localizer["Text5"];
        ViewData["Text6"] = _localizer["Text6"];
        ViewData["Text7"] = _localizer["Text7"];
        ViewData["Text8"] = _localizer["Text8"];
        ViewData["Text9"] = _localizer["Text9"];
        ViewData["Text10"] = _localizer["Text10"];
        ViewData["Text11"] = _localizer["Text11"];
        ViewData["Text12"] = _localizer["Text12"];
        ViewData["Text13"] = _localizer["Text13"];
        ViewData["Text14"] = _localizer["Text14"];
        ViewData["Text15"] = _localizer["Text15"];
        ViewData["Text16"] = _localizer["Text16"];
        ViewData["Text17"] = _localizer["Text17"];
        ViewData["Text18"] = _localizer["Text18"];
        ViewData["Text19"] = _localizer["Text19"];
        return View();
    }

   
    [HttpPost]
    public async Task<IActionResult> Checkout(Checkout checkout)
    {
        
        try
        {
            ViewData["Text1"] = _localizer["Text1"];
            ViewData["Text2"] = _localizer["Text2"];
            ViewData["Text3"] = _localizer["Text3"];
            ViewData["Text4"] = _localizer["Text4"];
            ViewData["Text5"] = _localizer["Text5"];
            ViewData["Text6"] = _localizer["Text6"];
            ViewData["Text7"] = _localizer["Text7"];
            ViewData["Text8"] = _localizer["Text8"];
            ViewData["Text9"] = _localizer["Text9"];
            ViewData["Text10"] = _localizer["Text10"];
            ViewData["Text11"] = _localizer["Text11"];
            ViewData["Text12"] = _localizer["Text12"];
            ViewData["Text13"] = _localizer["Text13"];
            ViewData["Text14"] = _localizer["Text14"];
            ViewData["Text15"] = _localizer["Text15"];
            ViewData["Text16"] = _localizer["Text16"];
            ViewData["Text17"] = _localizer["Text17"];
            ViewData["Text18"] = _localizer["Text18"];
            ViewData["Text19"] = _localizer["Text19"];
            var cart = GetCartItems();
            checkout.ProductIds = string.Join(",", cart.Select(i => i.ProductID.ToString()));
            await _checkoutWriteRepository.CreateAsync(checkout);
            await _checkoutWriteRepository.SaveChangesAsync();
            
            Response.Cookies.Delete(CartCookieKey);
            return RedirectToAction("Index", "Home");
        }
        catch (Exception e)
        {
            return RedirectToAction("Index", "Error");
        }
    }
    
    [HttpPost]
    public IActionResult UpdateQuantity(Guid productId, int quantity)
    {
        try
        {
            var cart = GetCartItems();

            var item = cart.FirstOrDefault(x => x.ProductID == productId);
            if (item != null && quantity > 0)
            {
                item.Quantity = quantity;
                SaveCartItems(cart);
            }

            return Ok();
        }
        catch (Exception e)
        {
            return RedirectToAction("Index", "Error");
        }
        
    }

}

