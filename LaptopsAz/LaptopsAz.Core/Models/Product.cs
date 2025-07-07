using LaptopsAz.Core.Enums;
using LaptopsAz.Core.Models.Common;

namespace LaptopsAz.Core.Models;

public class Product : BaseEntity
{
    public string ProductName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal DiscountPrice { get; set; }
    public Guid CategoryID { get; set; }
    public int Stock { get; set; }
    public string Brand { get; set; }
    public string ImageURL { get; set; }
    public HomePageTagEnum? HomePageTag { get; set; }
    public Category? Category { get; set; }
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    public ICollection<ProductSpec> ProductSpecs { get; set; } = new List<ProductSpec>();
    public ICollection<ProductPhoto> ProductPhotos { get; set; } = new List<ProductPhoto>();
}