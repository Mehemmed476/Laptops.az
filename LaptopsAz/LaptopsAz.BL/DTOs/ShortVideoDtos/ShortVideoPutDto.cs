namespace LaptopsAz.BL.DTOs.ShortVideoDtos;

public class ShortVideoPutDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Link { get; set; }
    public bool IsActive { get; set; }
}