using LaptopsAz.Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaptopsAz.DL.Repositories.Abstractions;

public interface IProductSpecReadRepository : IReadRepository<ProductSpec>
{
    Task<ICollection<SelectListItem>> SelectAllProductSpecAsync();
}