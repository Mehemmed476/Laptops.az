namespace LaptopsAz.BL.DTOs.CategoryDtos;

public class CategoryGetDto
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CategoryName { get; set; }
    public string ImageURL { get; set; }
    public bool IsTop { get; set; }
}