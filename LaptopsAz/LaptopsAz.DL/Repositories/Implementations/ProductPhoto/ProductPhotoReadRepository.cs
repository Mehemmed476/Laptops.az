using LaptopsAz.Core.Models;
using LaptopsAz.DL.Contexts;
using LaptopsAz.DL.Repositories.Abstractions;

namespace LaptopsAz.DL.Repositories.Implementations;

public class ProductPhotoReadRepository : ReadRepository<ProductPhoto>, IProductPhotoReadRepository
{
    public ProductPhotoReadRepository(AppDbContext context) : base(context)
    {
    }
}