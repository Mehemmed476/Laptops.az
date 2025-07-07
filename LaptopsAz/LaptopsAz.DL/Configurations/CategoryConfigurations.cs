using LaptopsAz.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaptopsAz.DL.Configurations;

public class CategoryConfigurations : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(c => c.CategoryName)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.HasMany(c => c.Products)
            .WithOne(p => p.Category) 
            .HasForeignKey(p => p.CategoryID)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(c => c.SliderItems)
            .WithOne(p => p.Category) 
            .HasForeignKey(p => p.CategoryId); 
    }
}