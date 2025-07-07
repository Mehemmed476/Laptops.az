using LaptopsAz.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaptopsAz.DL.Configurations;

public class ProductSpecConfigurations : IEntityTypeConfiguration<ProductSpec>
{
    public void Configure(EntityTypeBuilder<ProductSpec> builder)
    {
        builder.ToTable("ProductSpecs");

        builder.Property(ps => ps.ProductID)
            .IsRequired();

        builder.Property(ps => ps.SpecName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ps => ps.SpecValue)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasOne(ps => ps.Product)
            .WithMany(p => p.ProductSpecs)
            .HasForeignKey(ps => ps.ProductID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
