using AutoMapper;
using LaptopsAz.BL.DTOs.ProductDtos;
using LaptopsAz.BL.ExternalServices.Abstractions;
using LaptopsAz.BL.Helpers;
using LaptopsAz.BL.Services.Abstractions;
using LaptopsAz.Core.Enums;
using LaptopsAz.Core.Models;
using LaptopsAz.DL.Repositories.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LaptopsAz.BL.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IProductReadRepository _productReadRepository;
    private readonly IProductWriteRepository _productWriteRepository;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;
    private readonly IProductSpecWriteRepository _productSpecWriteRepository;
    private readonly IProductPhotoWriteRepository _productPhotoWriteRepository;
    IWebHostEnvironment _webHostEnvironment;
    
    public ProductService(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IMapper mapper, IFileService fileService, IWebHostEnvironment webHostEnvironment, IProductSpecWriteRepository productSpecWriteRepository, IProductPhotoWriteRepository productPhotoWriteRepository)
    {
        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;
        _mapper = mapper;
        _fileService = fileService;
        _webHostEnvironment = webHostEnvironment;
        _productSpecWriteRepository = productSpecWriteRepository;
        _productPhotoWriteRepository = productPhotoWriteRepository;
    }

    public async Task<Product> CreateProductAsync(ProductPostDto productPostDto)
    {
        Product product = _mapper.Map<Product>(productPostDto);
        product.CreatedAt = DateTime.UtcNow.AddHours(4);
        product.ImageURL = await _fileService.SaveFileAsync(productPostDto.Image, _webHostEnvironment.WebRootPath,new[] { ".png", ".jpg", ".jpeg" } );
        product.Slug = SlugHelper.GenerateSlug(product.ProductName);
        await _productWriteRepository.CreateAsync(product);
        var result = await _productWriteRepository.SaveChangesAsync();

        if (productPostDto.Specs != null && productPostDto.Specs.Any())
        {
            foreach (var spec in productPostDto.Specs)
            {
                var origSpec = _mapper.Map<ProductSpec>(spec);
                origSpec.ProductID = product.Id;
                await _productSpecWriteRepository.CreateAsync(origSpec);
                var resultSpec = await _productSpecWriteRepository.SaveChangesAsync();
                
                if (resultSpec == 0)
                {
                    throw new Exception("ProductSpec not created");
                }
            }
            
        }
        if (result == 0)
        {
            throw new Exception("Product not created");
        }

        return product;
    }

    public async Task DeleteProductAsync(Guid id)
    {
        if (!await _productReadRepository.IsExist(id)) throw new Exception("Product not found");
        Product product = await _productReadRepository.GetByIdAsync(id) ?? throw new Exception("Product not found");
        _productWriteRepository.Delete(product);
        var result = await _productWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("Product not created");
        }
    }

    public async Task<ICollection<ProductGetDto>> GetAllActiveProduct(int size = 10, int page = 0, Guid? categoryId = null)
    {
        if (categoryId != null)
        {
            ICollection<Product> productsWithCategory = await _productReadRepository
                .GetAllByCondition(c => !c.IsDeleted && c.CategoryID == categoryId, page, size).ToListAsync();
            return _mapper.Map<ICollection<ProductGetDto>>(productsWithCategory);
        }
        
        ICollection<Product> products = await _productReadRepository.GetAllByCondition(c => !c.IsDeleted, page, size).ToListAsync();
        return _mapper.Map<ICollection<ProductGetDto>>(products);
    }

    public async Task<ICollection<ProductGetDto>> GetAllActiveProductByIds(List<Guid> productIds, int size = 10, int page = 0, Guid? categoryId = null)
    {
        var query = _productReadRepository.GetAllByCondition(
            condition: p => productIds.Contains(p.Id) && !p.IsDeleted && (categoryId == null || p.CategoryID == categoryId),
            orderBy: q => q.OrderByDescending(p => p.CreatedAt)
        );


        if (categoryId != null)
        {
            query = query.Where(p => p.CategoryID == categoryId);
        }

        var products = await query
            .Skip(page * size)
            .Take(size)
            .Select(p => _mapper.Map<ProductGetDto>(p))
            .ToListAsync();

        return products;
    }

    public async Task<ICollection<ProductGetDto>> GetAllSoftDeletedProduct(int size = 10, int page = 0)
    {
        ICollection<Product> products = await _productReadRepository.GetAllByCondition(c => c.IsDeleted, page, size).ToListAsync();
        return _mapper.Map<ICollection<ProductGetDto>>(products);
    }

    public async Task<ICollection<ProductGetDto>> GetLatestProducts(int count)
    {
        ICollection<Product> products = await _productReadRepository.GetAllByCondition(
            condition: c => !c.IsDeleted, 
            orderBy: q => q.OrderByDescending(p => p.CreatedAt))
            .Take(count).ToListAsync();
        return _mapper.Map<ICollection<ProductGetDto>>(products);
    }

    public async Task<ICollection<ProductGetDto>> GetNewestProducts(int count)
    {
        ICollection<Product> products = await _productReadRepository.GetAllByCondition(
            condition: c => !c.IsDeleted && c.HomePageTag == HomePageTagEnum.NewProduct,
            orderBy: q => q.OrderByDescending(p => p.CreatedAt))
            .Take(count).ToListAsync();
        return _mapper.Map<ICollection<ProductGetDto>>(products);
    }

    public async Task<ICollection<ProductGetDto>> GetOurProducts(int count)
    {
        ICollection<Product> products = await _productReadRepository.GetAllByCondition(
            condition: c => !c.IsDeleted && c.HomePageTag == HomePageTagEnum.OurProduct,
            orderBy: q => q.OrderByDescending(p => p.CreatedAt))
            .Take(count).ToListAsync();
        return _mapper.Map<ICollection<ProductGetDto>>(products);
    }

    public async Task<ICollection<ProductGetDto>> GetHotDeals(int count)
    {
        ICollection<Product> products = await _productReadRepository.GetAllByCondition(
            condition: c => !c.IsDeleted && c.HomePageTag == HomePageTagEnum.HotDeal,
            orderBy: q => q.OrderByDescending(p => p.CreatedAt))
            .Take(count).ToListAsync();
        return _mapper.Map<ICollection<ProductGetDto>>(products);
    }

    public async Task<ICollection<ProductGetDto>> GetBestSellers(int count)
    {
        ICollection<Product> products = await _productReadRepository.GetAllByCondition(
            condition: c => !c.IsDeleted && c.HomePageTag == HomePageTagEnum.BestSeller,
            orderBy: q => q.OrderByDescending(p => p.CreatedAt))
            .Take(count).ToListAsync();
        return _mapper.Map<ICollection<ProductGetDto>>(products);
    }

    public async Task<ProductGetDto> GetByIdProductAsync(Guid id)
    {
        if (!await _productReadRepository.IsExist(id)) throw new Exception("Product not found");
        Product product = await _productReadRepository.GetByIdAsync(id, false, "Category") ?? throw new Exception("Product not found");
        return _mapper.Map<ProductGetDto>(product);
    }

    public async Task RestoreProductAsync(Guid id)
    {
        if (!await _productReadRepository.IsExist(id)) throw new Exception("Product not found");
        Product product = await _productReadRepository.GetOneByCondition(c => c.Id == id && c.IsDeleted, false) ?? throw new Exception("Product not found");
        product.IsDeleted = false;
        _productWriteRepository.Update(product);

        var result = await _productWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("Product not created");
        }
    }

    public async Task SoftDeleteProductAsync(Guid id)
    {
        if (!await _productReadRepository.IsExist(id)) throw new Exception("Product not found");
        Product product = await _productReadRepository.GetOneByCondition(c => c.Id == id && !c.IsDeleted, false) ?? throw new Exception("Product not found");
        product.IsDeleted = true;
        _productWriteRepository.Update(product);

        var result = await _productWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("Product not created");
        }
    }

    public async Task UpdateProductAsync(ProductPutDto productPutDto)
    {
        // 1. Mövcud məhsulu bazadan tapırıq. Bu, ən təhlükəsiz yoldur.
        Product? oldProduct = await _productReadRepository.GetByIdAsync(productPutDto.Id, true); // true -> tracking aktiv olsun
        if (oldProduct == null)
        {
            throw new Exception("Product not found");
        }
        productPutDto.ImageURL = oldProduct.ImageURL;
        // 2. DTO-dan gələn məlumatları mövcud obyektin üzərinə yazırıq (yenisini yaratmırıq)
        _mapper.Map(productPutDto, oldProduct);

        // 3. Əgər məhsul adı dəyişibsə, yeni slug yaradırıq
        if (oldProduct.ProductName != productPutDto.ProductName)
        {
            oldProduct.Slug = SlugHelper.GenerateSlug(productPutDto.ProductName);
        }
        
        // 4. Əgər yeni şəkil yüklənibsə...
        if (productPutDto.Image != null && productPutDto.Image.Length > 0)
        {
            // a) Faylı serverə yükləyirik
            var newImageURL = await _fileService.SaveFileAsync(
                productPutDto.Image,
                _webHostEnvironment.WebRootPath,
                new[] { ".png", ".jpg", ".jpeg" });

            // b) Əsas məhsulun "cover" şəklini yeniləyirik
            oldProduct.ImageURL = newImageURL;

            // c) Həmin şəkli həm də ProductPhotos cədvəlinə əlavə edirik
            var newProductPhoto = new ProductPhoto
            {
                PhotoURL = newImageURL,
                ProductId = oldProduct.Id,
                CreatedAt = DateTime.UtcNow.AddHours(4) // Baku vaxtı
            };
            await _productPhotoWriteRepository.CreateAsync(newProductPhoto);
        }

        else
        {
            oldProduct.ImageURL = productPutDto.ImageURL;
        }

        _productWriteRepository.Update(oldProduct);

        var result = await _productWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("Product could not be updated"); 
        }
    }
    
    public async Task<ICollection<SelectListItem>> SelectAllProduct()
    {
        return await _productReadRepository.SelectAllProductAsync();
    }

    public async Task<IEnumerable<ProductGetDto>> GetAllProducts()
    {
        IEnumerable<Product> products = await _productReadRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductGetDto>>(products);
    }

    public async Task<ProductGetDto> GetBySlugAsync(string slug)
    {
        Product? product = await _productReadRepository.GetBySlugAsync(slug);
        
        if (product == null) throw new Exception("Product not found");
        
        return _mapper.Map<ProductGetDto>(product);
    }
}