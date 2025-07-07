using LaptopsAz.Core.Models.Common;

namespace LaptopsAz.Core.Models;

public class Checkout : BaseEntity
{
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