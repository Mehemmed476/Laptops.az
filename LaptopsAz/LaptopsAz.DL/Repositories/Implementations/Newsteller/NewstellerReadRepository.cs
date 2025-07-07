using LaptopsAz.Core.Models;
using LaptopsAz.DL.Contexts;
using LaptopsAz.DL.Repositories.Abstractions;

namespace LaptopsAz.DL.Repositories.Implementations;

public class NewstellerReadRepository : ReadRepository<Newsteller>, INewstellerReadRepository
{
    public NewstellerReadRepository(AppDbContext context) : base(context)
    {
    }
}