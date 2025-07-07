using LaptopsAz.Core.Models.Common;

namespace LaptopsAz.Core.Models;

public class ShortVideo : BaseEntity
{
    public string Title { get; set; }
    public string Link { get; set; }
    public bool IsActive { get; set; }
}