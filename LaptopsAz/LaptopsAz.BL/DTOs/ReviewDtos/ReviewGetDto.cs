using LaptopsAz.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace LaptopsAz.BL.DTOs.ReviewDtos;

public class ReviewGetDto
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid ProductID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Comment { get; set; }

    public Product? Product { get; set; }
}