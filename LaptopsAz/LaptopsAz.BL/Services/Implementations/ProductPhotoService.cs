using AutoMapper;
using LaptopsAz.BL.DTOs.ProductPhotoDtos;
using LaptopsAz.BL.ExternalServices.Abstractions;
using LaptopsAz.BL.Services.Abstractions;
using LaptopsAz.Core.Models;
using LaptopsAz.DL.Repositories.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace LaptopsAz.BL.Services.Implementations;

public class ProductPhotoService : IProductPhotoService
{
    private readonly IProductPhotoReadRepository _productPhotoReadRepository;
    private readonly IProductPhotoWriteRepository _productPhotoWriteRepository;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;
    IWebHostEnvironment _webHostEnvironment;
    public ProductPhotoService(IProductPhotoReadRepository productPhotoReadRepository, IMapper mapper, IProductPhotoWriteRepository productPhotoWriteRepository, IFileService fileService, IWebHostEnvironment webHostEnvironment)
    {
        _productPhotoReadRepository = productPhotoReadRepository;
        _mapper = mapper;
        _productPhotoWriteRepository = productPhotoWriteRepository;
        _fileService = fileService;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<ICollection<ProductPhotoGetDto>> GetAllProductPhoto(Guid productId)
    {
        ICollection<ProductPhoto> productPhotos = await _productPhotoReadRepository
            .GetAllByCondition(p => p.ProductId == productId, null).ToListAsync();
        
        return _mapper.Map<ICollection<ProductPhotoGetDto>>(productPhotos);
    }

    public async Task<ICollection<ProductPhotoGetDto>> GetByProductIdProductPhotosAsync(Guid productId)
    {
        ICollection<ProductPhoto> photos = await _productPhotoReadRepository.GetAllByCondition(p => p.ProductId == productId && !p.IsDeleted, null).ToListAsync();
        return _mapper.Map<ICollection<ProductPhotoGetDto>>(photos);
    }

    public async Task DeleteProductPhotoAsync(Guid id)
    {
        if (!await _productPhotoReadRepository.IsExist(id)) throw new Exception("ProductPhoto not found");
        ProductPhoto productPhoto = await _productPhotoReadRepository.GetByIdAsync(id) ?? throw new Exception("ProductPhoto not found");
        _productPhotoWriteRepository.Delete(productPhoto);

        var result = await _productPhotoWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("ProductPhoto not created");
        }
    }

    public async Task UpdateProductPhotoAsync(ProductPhotoPutDto dto)
    {
        ProductPhoto productPhoto = _mapper.Map<ProductPhoto>(dto);
        productPhoto.PhotoURL = await _fileService.SaveFileAsync(
            dto.Image,
            _webHostEnvironment.WebRootPath,
            new[] { ".png", ".jpg", ".jpeg" });
        _productPhotoWriteRepository.Update(productPhoto);

        var result = await _productPhotoWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("ProductPhoto not created");
        }
    }

    public async Task<ProductPhotoGetDto> GetByIdProductPhotoAsync(Guid id)
    {
        if (!await _productPhotoReadRepository.IsExist(id)) throw new Exception("ProductPhoto not found");
        ProductPhoto productPhoto = await _productPhotoReadRepository.GetByIdAsync(id) ?? throw new Exception("ProductPhoto not found");
        return _mapper.Map<ProductPhotoGetDto>(productPhoto);
    }
}