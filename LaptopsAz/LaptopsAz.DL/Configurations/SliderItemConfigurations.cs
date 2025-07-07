using LaptopsAz.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaptopsAz.DL.Configurations;

public class SliderItemConfigurations : IEntityTypeConfiguration<SliderItem>
{
    public void Configure(EntityTypeBuilder<SliderItem> builder)
    {
        builder.Property(s => s.SmallTitle).HasMaxLength(50).IsRequired();
        builder.Property(s => s.LargeTitle).HasMaxLength(50).IsRequired();
        builder.Property(s => s.Description).HasMaxLength(250).IsRequired();
        builder.Property(s => s.ImageURL).HasMaxLength(250).IsRequired();

        builder.HasOne(s => s.Category)
            .WithMany(s => s.SliderItems)
            .HasForeignKey(s => s.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}