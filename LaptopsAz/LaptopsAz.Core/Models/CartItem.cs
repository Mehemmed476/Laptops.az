using System.Globalization;
using LaptopsAz.Core.Models.Common;
using Microsoft.AspNetCore.Identity;

namespace LaptopsAz.Core.Models;

public class CartItem : BaseEntity
{ 
    public Guid ProductID { get; set; }
    public string ProductName { get; set; }
    public string ImageURL { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public Product? Product { get; set; }
}