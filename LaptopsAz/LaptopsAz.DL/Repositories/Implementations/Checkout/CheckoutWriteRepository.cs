using LaptopsAz.Core.Models;
using LaptopsAz.DL.Contexts;
using LaptopsAz.DL.Repositories.Abstractions;

namespace LaptopsAz.DL.Repositories.Implementations;

public class CheckoutWriteRepository : WriteRepository<Checkout>, ICheckoutWriteRepository
{
    public CheckoutWriteRepository(AppDbContext context) : base(context)
    {
    }
}