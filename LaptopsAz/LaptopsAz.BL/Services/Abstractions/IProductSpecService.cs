using LaptopsAz.BL.DTOs.ProductSpecDtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaptopsAz.BL.Services.Abstractions;

public interface IProductSpecService
{
    Task CreateProductSpecAsync(ProductSpecPostDto dto);
    Task DeleteProductSpecAsync(Guid id);
    Task SoftDeleteProductSpecAsync(Guid id);
    Task RestoreProductSpecAsync(Guid id);
    Task UpdateProductSpecAsync(ProductSpecPutDto dto);
    Task<ICollection<ProductSpecGetDto>> GetAllActiveProductSpec(Guid productId, int size = 20, int page = 0);
    Task<ICollection<ProductSpecGetDto>> GetAllSoftDeletedProductSpec(int size = 10, int page = 0);
    Task<ProductSpecGetDto> GetByIdProductSpecAsync(Guid id);
    Task<ICollection<ProductSpecGetDto>> GetByProductIdProductSpecsAsync(Guid productId);
}