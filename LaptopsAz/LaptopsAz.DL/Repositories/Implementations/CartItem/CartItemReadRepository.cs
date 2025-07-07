using LaptopsAz.Core.Models;
using LaptopsAz.DL.Contexts;
using LaptopsAz.DL.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaptopsAz.DL.Repositories.Implementations;

public class CartItemReadRepository : ReadRepository<CartItem>,  ICartItemReadRepository
{
    public CartItemReadRepository(AppDbContext context) : base(context)
    {
    }
}