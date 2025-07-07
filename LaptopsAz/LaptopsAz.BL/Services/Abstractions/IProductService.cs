using LaptopsAz.BL.DTOs.ProductDtos;
using LaptopsAz.Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaptopsAz.BL.Services.Abstractions;

public interface IProductService
{
    Task<Product> CreateProductAsync(ProductPostDto dto);
    Task DeleteProductAsync(Guid id);
    Task SoftDeleteProductAsync(Guid id);
    Task RestoreProductAsync(Guid id);
    Task UpdateProductAsync(ProductPutDto dto);
    Task<ICollection<ProductGetDto>> GetAllActiveProduct(int size = 10, int page = 0, Guid? categoryId = null);

    Task<ICollection<ProductGetDto>> GetAllActiveProductByIds(List<Guid> productIds, int size = 10, int page = 0,
        Guid? categoryId = null);
    Task<ICollection<ProductGetDto>> GetAllSoftDeletedProduct(int size = 10, int page = 0);
    Task<ICollection<ProductGetDto>> GetLatestProducts(int count);
    Task<ICollection<ProductGetDto>> GetNewestProducts(int count);
    Task<ICollection<ProductGetDto>> GetOurProducts(int count);
    Task<ICollection<ProductGetDto>> GetHotDeals(int count);
    Task<ICollection<ProductGetDto>> GetBestSellers(int count);
    Task<ProductGetDto> GetByIdProductAsync(Guid id);
    Task<ICollection<SelectListItem>> SelectAllProduct();
    Task<IEnumerable<ProductGetDto>> GetAllProducts();
}