using LaptopsAz.Core.Models;
using LaptopsAz.DL.Contexts;
using LaptopsAz.DL.Repositories.Abstractions;

namespace LaptopsAz.DL.Repositories.Implementations;

public class SliderItemReadRepository : ReadRepository<SliderItem>, ISliderItemReadRepository
{
    public SliderItemReadRepository(AppDbContext context) : base(context)
    {
    }
}