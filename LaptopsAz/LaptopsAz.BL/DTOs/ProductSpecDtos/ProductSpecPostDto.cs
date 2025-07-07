using LaptopsAz.Core.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaptopsAz.BL.DTOs.ProductSpecDtos;

public class ProductSpecPostDto
{
    public ComputerSpecification SpecName { get; set; }
    public string SpecValue { get; set; }
}
