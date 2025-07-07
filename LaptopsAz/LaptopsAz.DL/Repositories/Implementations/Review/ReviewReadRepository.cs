using LaptopsAz.Core.Models;
using LaptopsAz.DL.Contexts;
using LaptopsAz.DL.Repositories.Abstractions;

namespace LaptopsAz.DL.Repositories.Implementations;

public class ReviewReadRepository : ReadRepository<Review>, IReviewReadRepository
{
    public ReviewReadRepository(AppDbContext context) : base(context)
    {
    }
}