using LaptopsAz.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaptopsAz.DL.Configurations;

public class ProductPhotoConfigurations : IEntityTypeConfiguration<ProductPhoto>
{
    public void Configure(EntityTypeBuilder<ProductPhoto> builder)
    {
        builder.Property(p => p.PhotoURL)
            .IsRequired();
        
        builder.HasOne(p => p.Product)
            .WithMany(p => p.ProductPhotos)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}