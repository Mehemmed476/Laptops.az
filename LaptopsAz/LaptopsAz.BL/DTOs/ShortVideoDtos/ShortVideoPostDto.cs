namespace LaptopsAz.BL.DTOs.ShortVideoDtos;

public class ShortVideoPostDto
{
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Link { get; set; }
    public bool IsActive { get; set; }
}