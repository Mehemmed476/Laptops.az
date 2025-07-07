namespace LaptopsAz.BL.DTOs.BrandSliderDtos;

public class BrandSliderGetDto
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public string Title { get; set; }
    public string ImageURL { get; set; }
}