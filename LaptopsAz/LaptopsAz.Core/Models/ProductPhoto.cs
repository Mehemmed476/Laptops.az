using LaptopsAz.Core.Models.Common;

namespace LaptopsAz.Core.Models;

public class ProductPhoto : BaseEntity
{
    public string PhotoURL { get; set; }
    
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
}