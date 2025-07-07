using LaptopsAz.Core.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaptopsAz.BL.DTOs.ProductSpecDtos;

public class ProductSpecPutDto
{
    public Guid Id { get; set; }
    public Guid ProductID { get; set; }
    public ComputerSpecification SpecName { get; set; }
    public string SpecValue { get; set; }
    
    public ICollection<SelectListItem>? Products { get; set; }
    public List<SelectListItem>? AllSpecNames { get; set; }
}