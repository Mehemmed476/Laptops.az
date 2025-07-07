namespace LaptopsAz.BL.DTOs.NewstellerDtos;

public class NewstellerGetDto
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public string PhoneNumber { get; set; }
}