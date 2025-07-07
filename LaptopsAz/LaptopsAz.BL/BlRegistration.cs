using FluentValidation;
using FluentValidation.AspNetCore;
using LaptopsAz.BL.ExternalServices.Abstractions;
using LaptopsAz.BL.ExternalServices.Implementations;
using LaptopsAz.BL.Profiles.CategoryProfiles;
using LaptopsAz.BL.Services.Abstractions;
using LaptopsAz.BL.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace LaptopsAz.BL;

public static class BlRegistration
{
    public static void AddBlServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(CategoryProfile).Assembly);
        /*services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(typeof(CategoryProfile).Assembly);*/

        services.AddScoped<IIdentityService, IdentityService>();
        
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductSpecService, ProductSpecService>();
        services.AddScoped<IReviewService, ReviewService>();
        services.AddScoped<ISliderItemService, SliderItemService>();
        services.AddScoped<IBrandSliderService, BrandSliderService>();
        services.AddScoped<INewstellerService, NewstellerService>();
        services.AddScoped<IProductPhotoService, ProductPhotoService>();
        services.AddScoped<ICheckoutService, CheckoutService>();
        services.AddScoped<IShortVideoService, ShortVideoService>();
        
        services.AddScoped<IFileService, FileService>();
    }
}