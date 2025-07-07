namespace LaptopsAz.BL.DTOs.ShortVideoDtos;

public class ShortVideoGetDto
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Title { get; set; }
    public string Link { get; set; }
    public bool IsActive { get; set; }
}