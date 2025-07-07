using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaptopsAz.BL.DTOs.ReviewDtos;

public class ReviewPostDto
{
    public Guid ProductID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Comment { get; set; }
    
    public ICollection<SelectListItem>? Products { get; set; }
}