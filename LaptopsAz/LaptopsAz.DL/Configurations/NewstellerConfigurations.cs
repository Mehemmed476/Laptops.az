using LaptopsAz.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaptopsAz.DL.Configurations;

public class NewstellerConfigurations : IEntityTypeConfiguration<Newsteller>
{
    public void Configure(EntityTypeBuilder<Newsteller> builder)
    {
        builder.Property(b => b.PhoneNumber).IsRequired();
    }
}