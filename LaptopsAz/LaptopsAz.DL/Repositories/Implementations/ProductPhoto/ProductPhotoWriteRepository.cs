using LaptopsAz.Core.Models;
using LaptopsAz.DL.Contexts;
using LaptopsAz.DL.Repositories.Abstractions;

namespace LaptopsAz.DL.Repositories.Implementations;

public class ProductPhotoWriteRepository : WriteRepository<ProductPhoto>, IProductPhotoWriteRepository
{
    public ProductPhotoWriteRepository(AppDbContext context) : base(context)
    {
    }
}