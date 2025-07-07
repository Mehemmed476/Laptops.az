using LaptopsAz.Core.Models.Common;

namespace LaptopsAz.Core.Models;

public class Category : BaseEntity
{
    public string CategoryName { get; set; }
    public string ImageURL { get; set; }
    public bool IsTop { get; set; }
    public ICollection<Product> Products { get; set; } =  new List<Product>();
    public ICollection<SliderItem> SliderItems { get; set; } =  new List<SliderItem>();
}