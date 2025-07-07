using LaptopsAz.Core.Enums;
using LaptopsAz.Core.Models.Common;

namespace LaptopsAz.Core.Models;

public class ProductSpec : BaseEntity
{
    public Guid ProductID { get; set; }
    public ComputerSpecification SpecName { get; set; }
    public string SpecValue { get; set; }

    public Product? Product { get; set; }
}