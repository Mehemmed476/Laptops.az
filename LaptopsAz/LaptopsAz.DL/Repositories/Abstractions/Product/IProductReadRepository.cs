using LaptopsAz.Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaptopsAz.DL.Repositories.Abstractions;

public interface IProductReadRepository : IReadRepository<Product>
{
    Task<ICollection<SelectListItem>> SelectAllProductAsync();
    Task<Product> GetBySlugAsync(string slug);
}