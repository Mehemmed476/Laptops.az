using LaptopsAz.Core.Models.Common;

namespace LaptopsAz.Core.Models;

public class SliderItem : BaseEntity
{
    public string SmallTitle { get; set; }
    public string LargeTitle { get; set; }
    public string Description { get; set; }
    public string ImageURL { get; set; }
    public Guid CategoryId { get; set; }
    
    public Category? Category { get; set; }
}