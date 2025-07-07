using LaptopsAz.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaptopsAz.DL.Configurations;

public class BrandSliderConfigurations : IEntityTypeConfiguration<BrandSlider>
{
    public void Configure(EntityTypeBuilder<BrandSlider> builder)
    {
        builder.Property(p => p.Title).IsRequired().HasMaxLength(30);
        builder.Property(p => p.ImageURL).IsRequired().HasMaxLength(200);
    }
}