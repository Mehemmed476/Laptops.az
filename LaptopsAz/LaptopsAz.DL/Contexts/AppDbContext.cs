using System.Reflection;
using LaptopsAz.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LaptopsAz.DL.Contexts;

public class AppDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductSpec> ProductSpecs { get; set; }
    public DbSet<ProductPhoto> ProductPhotos { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Checkout> Checkouts { get; set; }
    public DbSet<Review> Reviews { get; set; }
    
    public DbSet<SliderItem> SliderItems { get; set; }
    public DbSet<BrandSlider> BrandSliders { get; set; }
    
    public DbSet<Newsteller> Newstellers { get; set; }
    public DbSet<ShortVideo> ShortVideos { get; set; }
    
    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    base.OnConfiguring(optionsBuilder);
    optionsBuilder.UseSqlServer("Server=localhost;Database=LaptopsAzDb;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True");
    }*/
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "6d16558a-ba79-4fb5-9717-bd333cfc2b0d", Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Id = "287f30c4-6d0f-4687-b117-49d810376603", Name = "User", NormalizedName = "USER" }
        );
        

        IdentityUser admin = new()
        {
            Id = "c10c9801-9957-4018-8e48-0c7812d47b50",
            UserName = "admin",
            NormalizedUserName = "ADMIN"
        };

        PasswordHasher<IdentityUser> hasher = new();
        admin.PasswordHash = hasher.HashPassword(admin, "admin123");

        builder.Entity<IdentityUser>().HasData(admin);

        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { UserId = admin.Id, RoleId = "6d16558a-ba79-4fb5-9717-bd333cfc2b0d" }
        );
        
        
        base.OnModelCreating(builder);
    }
}