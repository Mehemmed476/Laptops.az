using LaptopsAz.Core.Models;
using LaptopsAz.DL.Contexts;
using LaptopsAz.DL.Repositories.Abstractions;

namespace LaptopsAz.DL.Repositories.Implementations;

public class SliderItemWriteRepository : WriteRepository<SliderItem>, ISliderItemWriteRepository
{
    public SliderItemWriteRepository(AppDbContext context) : base(context)
    {
    }
}