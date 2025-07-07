using LaptopsAz.Core.Models;
using LaptopsAz.DL.Contexts;
using LaptopsAz.DL.Repositories.Abstractions;

namespace LaptopsAz.DL.Repositories.Implementations;

public class BrandSliderWriteRepository : WriteRepository<BrandSlider>, IBrandSliderWriteRepository
{
    public BrandSliderWriteRepository(AppDbContext context) : base(context)
    {
    }
}