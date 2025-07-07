using LaptopsAz.Core.Models;
using LaptopsAz.DL.Contexts;
using LaptopsAz.DL.Repositories.Abstractions;

namespace LaptopsAz.DL.Repositories.Implementations;

public class BrandSliderReadRepository : ReadRepository<BrandSlider>, IBrandSliderReadRepository
{
    public BrandSliderReadRepository(AppDbContext context) : base(context)
    {
    }
}