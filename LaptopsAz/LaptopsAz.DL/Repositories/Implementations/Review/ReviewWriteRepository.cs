using LaptopsAz.Core.Models;
using LaptopsAz.DL.Contexts;
using LaptopsAz.DL.Repositories.Abstractions;

namespace LaptopsAz.DL.Repositories.Implementations;

public class ReviewWriteRepository  : WriteRepository<Review>, IReviewWriteRepository
{
    public ReviewWriteRepository(AppDbContext context) : base(context)
    {
    }
}