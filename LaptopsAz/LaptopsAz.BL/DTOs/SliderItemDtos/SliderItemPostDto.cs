using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaptopsAz.BL.DTOs.SliderItemDtos;

public class SliderItemPostDto
{
    public string SmallTitle { get; set; }
    public string LargeTitle { get; set; }
    public string Description { get; set; }
    public IFormFile Image { get; set; }
    public Guid CategoryID { get; set; }
    public ICollection<SelectListItem>? Categories { get; set; }
}