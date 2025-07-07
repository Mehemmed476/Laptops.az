using LaptopsAz.Core.Models;
using LaptopsAz.DL.Contexts;
using LaptopsAz.DL.Repositories.Abstractions;

namespace LaptopsAz.DL.Repositories.Implementations;

public class ProductSpecWriteRepository : WriteRepository<ProductSpec>, IProductSpecWriteRepository
{
    public ProductSpecWriteRepository(AppDbContext context) : base(context)
    {
    }
}