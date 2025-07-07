using LaptopsAz.Core.Models;
using LaptopsAz.DL.Contexts;
using LaptopsAz.DL.Repositories.Abstractions;

namespace LaptopsAz.DL.Repositories.Implementations;

public class CartItemWriteRepository  : WriteRepository<CartItem>, ICartItemWriteRepository
{
    public CartItemWriteRepository(AppDbContext context) : base(context)
    {
    }
}