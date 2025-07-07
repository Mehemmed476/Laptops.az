using LaptopsAz.DL.Contexts;
using LaptopsAz.DL.Repositories.Abstractions;
using LaptopsAz.DL.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LaptopsAz.DL;

public static class DlRegistrations
{
    public static void AddDlServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("MsSql"));
            opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        
        services.AddScoped<IProductSpecReadRepository, ProductSpecReadRepository>();
        services.AddScoped<IProductSpecWriteRepository, ProductSpecWriteRepository>();

        services.AddScoped<ICartItemReadRepository, CartItemReadRepository>();
        services.AddScoped<ICartItemWriteRepository, CartItemWriteRepository>();

        services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
        services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
        
        services.AddScoped<IReviewReadRepository, ReviewReadRepository>();
        services.AddScoped<IReviewWriteRepository, ReviewWriteRepository>();

        services.AddScoped<ISliderItemReadRepository, SliderItemReadRepository>();
        services.AddScoped<ISliderItemWriteRepository, SliderItemWriteRepository>();

        services.AddScoped<IBrandSliderReadRepository, BrandSliderReadRepository>();
        services.AddScoped<IBrandSliderWriteRepository, BrandSliderWriteRepository>();

        services.AddScoped<INewstellerReadRepository, NewstellerReadRepository>();
        services.AddScoped<INewstellerWriteRepository, NewstellerWriteRepository>();
        
        services.AddScoped<IProductPhotoReadRepository, ProductPhotoReadRepository>();
        services.AddScoped<IProductPhotoWriteRepository, ProductPhotoWriteRepository>();
        
        services.AddScoped<ICheckoutReadRepository, CheckoutReadRepository>();
        services.AddScoped<ICheckoutWriteRepository, CheckoutWriteRepository>();

        services.AddScoped<IShortVideoReadRepository, ShortVideoReadRepository>();
        services.AddScoped<IShortVideoWriteRepository, ShortVideoWriteRepository>();
    }
}