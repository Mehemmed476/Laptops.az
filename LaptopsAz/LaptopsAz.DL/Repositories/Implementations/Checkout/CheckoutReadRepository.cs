using LaptopsAz.Core.Models;
using LaptopsAz.DL.Contexts;
using LaptopsAz.DL.Repositories.Abstractions;

namespace LaptopsAz.DL.Repositories.Implementations;

public class CheckoutReadRepository : ReadRepository<Checkout>, ICheckoutReadRepository
{
    public CheckoutReadRepository(AppDbContext context) : base(context)
    {
    }
}