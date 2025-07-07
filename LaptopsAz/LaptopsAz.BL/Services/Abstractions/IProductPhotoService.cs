using LaptopsAz.BL.DTOs.ProductPhotoDtos;
using LaptopsAz.Core.Models;

namespace LaptopsAz.BL.Services.Abstractions;

public interface IProductPhotoService
{
    Task<ICollection<ProductPhotoGetDto>> GetAllProductPhoto(Guid productId);
    Task<ICollection<ProductPhotoGetDto>> GetByProductIdProductPhotosAsync(Guid productId);
    Task DeleteProductPhotoAsync(Guid id);
    Task UpdateProductPhotoAsync(ProductPhotoPutDto dto);
    Task<ProductPhotoGetDto> GetByIdProductPhotoAsync(Guid id);
}