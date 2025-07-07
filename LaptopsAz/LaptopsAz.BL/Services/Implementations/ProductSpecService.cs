using AutoMapper;
using LaptopsAz.BL.DTOs.ProductSpecDtos;
using LaptopsAz.BL.Services.Abstractions;
using LaptopsAz.Core.Models;
using LaptopsAz.DL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace LaptopsAz.BL.Services.Implementations;

public class ProductSpecService : IProductSpecService
{
    private readonly IProductSpecReadRepository _productSpecReadRepository;
    private readonly IProductSpecWriteRepository _productSpecWriteRepository;
    private readonly IMapper _mapper;
    
    public ProductSpecService(IProductSpecReadRepository productSpecReadRepository, IProductSpecWriteRepository productSpecWriteRepository, IMapper mapper)
    {
        _productSpecReadRepository = productSpecReadRepository;
        _productSpecWriteRepository = productSpecWriteRepository;
        _mapper = mapper;
    }

    public async Task CreateProductSpecAsync(ProductSpecPostDto productSpecPostDto)
    {
        ProductSpec productSpec = _mapper.Map<ProductSpec>(productSpecPostDto);
        await _productSpecWriteRepository.CreateAsync(productSpec);
        var result = await _productSpecWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("ProductSpec not created");
        }
    }

    public async Task DeleteProductSpecAsync(Guid id)
    {
        if (!await _productSpecReadRepository.IsExist(id)) throw new Exception("ProductSpec not found");
        ProductSpec productSpec = await _productSpecReadRepository.GetByIdAsync(id) ?? throw new Exception("ProductSpec not found");
        _productSpecWriteRepository.Delete(productSpec);

        var result = await _productSpecWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("ProductSpec not created");
        }
    }

    public async Task<ICollection<ProductSpecGetDto>> GetAllActiveProductSpec(Guid productId, int size = 20, int page = 0)
    {
        ICollection<ProductSpec> productSpecs = await _productSpecReadRepository.GetAllByCondition(c => !c.IsDeleted && c.ProductID == productId, page, size).ToListAsync();
        return _mapper.Map<ICollection<ProductSpecGetDto>>(productSpecs);
    }

    public async Task<ICollection<ProductSpecGetDto>> GetAllSoftDeletedProductSpec(int size = 10, int page = 0)
    {
        ICollection<ProductSpec> productSpecs = await _productSpecReadRepository.GetAllByCondition(c => c.IsDeleted, page, size).ToListAsync();
        return _mapper.Map<ICollection<ProductSpecGetDto>>(productSpecs);
    }

    public async Task<ProductSpecGetDto> GetByIdProductSpecAsync(Guid id)
    {
        if (!await _productSpecReadRepository.IsExist(id)) throw new Exception("ProductSpec not found");
        ProductSpec productSpec = await _productSpecReadRepository.GetByIdAsync(id) ?? throw new Exception("ProductSpec not found");
        return _mapper.Map<ProductSpecGetDto>(productSpec);
    }

    public async Task<ICollection<ProductSpecGetDto>> GetByProductIdProductSpecsAsync(Guid productId)
    {
        ICollection<ProductSpec> specs = await _productSpecReadRepository.GetAllByCondition(p => p.ProductID == productId && !p.IsDeleted).ToListAsync();
        return _mapper.Map<ICollection<ProductSpecGetDto>>(specs);
    }

    public async Task RestoreProductSpecAsync(Guid id)
    {
        if (!await _productSpecReadRepository.IsExist(id)) throw new Exception("ProductSpec not found");
        ProductSpec productSpec = await _productSpecReadRepository.GetOneByCondition(c => c.Id == id && c.IsDeleted, false) ?? throw new Exception("ProductSpec not found");
        productSpec.IsDeleted = false;
        _productSpecWriteRepository.Update(productSpec);

        var result = await _productSpecWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("ProductSpec not created");
        }
    }

    public async Task SoftDeleteProductSpecAsync(Guid id)
    {
        if (!await _productSpecReadRepository.IsExist(id)) throw new Exception("ProductSpec not found");
        ProductSpec productSpec = await _productSpecReadRepository.GetOneByCondition(c => c.Id == id && !c.IsDeleted, false) ?? throw new Exception("ProductSpec not found");
        productSpec.IsDeleted = true;
        _productSpecWriteRepository.Update(productSpec);

        var result = await _productSpecWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("ProductSpec not created");
        }
    }

    public async Task UpdateProductSpecAsync(ProductSpecPutDto productSpecPutDto)
    {
        ProductSpec productSpec = _mapper.Map<ProductSpec>(productSpecPutDto);
        _productSpecWriteRepository.Update(productSpec);

        var result = await _productSpecWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("ProductSpec not created");
        }
    }
}