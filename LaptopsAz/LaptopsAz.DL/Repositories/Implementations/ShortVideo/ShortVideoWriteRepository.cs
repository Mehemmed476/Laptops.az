using LaptopsAz.Core.Models;
using LaptopsAz.DL.Contexts;
using LaptopsAz.DL.Repositories.Abstractions;

namespace LaptopsAz.DL.Repositories.Implementations;

public class ShortVideoWriteRepository : WriteRepository<ShortVideo>, IShortVideoWriteRepository
{
    public ShortVideoWriteRepository(AppDbContext context) : base(context)
    {
    }
}