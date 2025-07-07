namespace LaptopsAz.BL.DTOs.CheckoutDtos;

public class CheckoutGetDto
{
    public Guid Id { get; set; }
    public bool IsCompleted { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string City { get; set; }
    public string StreetAddress { get; set; }
    public string? ApartmentNumber { get; set; }
    public string? Notes { get; set; }
    public string? ProductIds { get; set; }
}