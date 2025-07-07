using LaptopsAz.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaptopsAz.DL.Configurations;

public class ShortVideoConfigurations : IEntityTypeConfiguration<ShortVideo>
{
    public void Configure(EntityTypeBuilder<ShortVideo> builder)
    {
    }
}