using LaptopsAz.Core.Enums;
using LaptopsAz.Core.Models;

namespace LaptopsAz.BL.DTOs.ProductSpecDtos;

public class ProductSpecGetDto
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid ProductID { get; set; }
    public ComputerSpecification SpecName { get; set; }
    public string SpecValue { get; set; }

    public Product? Product { get; set; }
}