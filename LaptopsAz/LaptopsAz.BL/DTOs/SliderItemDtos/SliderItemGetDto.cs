using LaptopsAz.Core.Models;

namespace LaptopsAz.BL.DTOs.SliderItemDtos;

public class SliderItemGetDto
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public string SmallTitle { get; set; }
    public string LargeTitle { get; set; }
    public string Description { get; set; }
    public string ImageURL { get; set; }
    public Guid CategoryId { get; set; }
    
    public Category? Category { get; set; }
}