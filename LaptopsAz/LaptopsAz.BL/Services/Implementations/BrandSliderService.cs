using AutoMapper;
using LaptopsAz.BL.DTOs.BrandSliderDtos;
using LaptopsAz.BL.ExternalServices.Abstractions;
using LaptopsAz.BL.Services.Abstractions;
using LaptopsAz.Core.Models;
using LaptopsAz.DL.Repositories.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace LaptopsAz.BL.Services.Implementations;

public class BrandSliderService : IBrandSliderService
{
    private readonly IBrandSliderReadRepository _brandSliderReadRepository;
    private readonly IBrandSliderWriteRepository _brandSliderWriteRepository;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;
    IWebHostEnvironment _webHostEnvironment;
    
    public BrandSliderService(IBrandSliderReadRepository brandSliderReadRepository, IBrandSliderWriteRepository brandSliderWriteRepository, IMapper mapper, IFileService fileService, IWebHostEnvironment webHostEnvironment)
    {
        _brandSliderReadRepository = brandSliderReadRepository;
        _brandSliderWriteRepository = brandSliderWriteRepository;
        _mapper = mapper;
        _fileService = fileService;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task CreateBrandSliderAsync(BrandSliderPostDto brandSliderPostDto)
    {
        BrandSlider brandSlider = _mapper.Map<BrandSlider>(brandSliderPostDto);
        brandSlider.CreatedAt = DateTime.UtcNow.AddHours(4);
        brandSlider.ImageURL = await _fileService.SaveFileAsync(brandSliderPostDto.Image, _webHostEnvironment.WebRootPath,new[] { ".png", ".jpg", ".jpeg" } );
        await _brandSliderWriteRepository.CreateAsync(brandSlider);
        var result = await _brandSliderWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("BrandSlider not created");
        }
    }

    public async Task DeleteBrandSliderAsync(Guid id)
    {
        if (!await _brandSliderReadRepository.IsExist(id)) throw new Exception("BrandSlider not found");
        BrandSlider brandSlider = await _brandSliderReadRepository.GetByIdAsync(id) ?? throw new Exception("BrandSlider not found");
        _brandSliderWriteRepository.Delete(brandSlider);

        var result = await _brandSliderWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("BrandSlider not created");
        }
    }

    public async Task<ICollection<BrandSliderGetDto>> GetAllActiveBrandSlider(int size = 10, int page = 0)
    {
        ICollection<BrandSlider> brandSliders = await _brandSliderReadRepository.GetAllByCondition(c => !c.IsDeleted, page, size).ToListAsync();
        return _mapper.Map<ICollection<BrandSliderGetDto>>(brandSliders);
    }

    public async Task<ICollection<BrandSliderGetDto>> GetAllSoftDeletedBrandSlider(int size = 10, int page = 0)
    {
        ICollection<BrandSlider> brandSliders = await _brandSliderReadRepository.GetAllByCondition(c => c.IsDeleted, page, size).ToListAsync();
        return _mapper.Map<ICollection<BrandSliderGetDto>>(brandSliders);
    }

    public async Task<BrandSliderGetDto> GetByIdBrandSliderAsync(Guid id)
    {
        if (!await _brandSliderReadRepository.IsExist(id)) throw new Exception("BrandSlider not found");
        BrandSlider brandSlider = await _brandSliderReadRepository.GetByIdAsync(id) ?? throw new Exception("BrandSlider not found");
        return _mapper.Map<BrandSliderGetDto>(brandSlider);
    }

    public async Task RestoreBrandSliderAsync(Guid id)
    {
        if (!await _brandSliderReadRepository.IsExist(id)) throw new Exception("BrandSlider not found");
        BrandSlider brandSlider = await _brandSliderReadRepository.GetOneByCondition(c => c.Id == id && c.IsDeleted, false) ?? throw new Exception("BrandSlider not found");
        brandSlider.IsDeleted = false;
        _brandSliderWriteRepository.Update(brandSlider);

        var result = await _brandSliderWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("BrandSlider not created");
        }
    }

    public async Task SoftDeleteBrandSliderAsync(Guid id)
    {
        if (!await _brandSliderReadRepository.IsExist(id)) throw new Exception("BrandSlider not found");
        BrandSlider brandSlider = await _brandSliderReadRepository.GetOneByCondition(c => c.Id == id && !c.IsDeleted, false) ?? throw new Exception("BrandSlider not found");
        brandSlider.IsDeleted = true;
        _brandSliderWriteRepository.Update(brandSlider);

        var result = await _brandSliderWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("BrandSlider not created");
        }
    }

    public async Task UpdateBrandSliderAsync(BrandSliderPutDto brandSliderPutDto)
    {
        BrandSlider oldBrandSlider = await _brandSliderReadRepository.GetByIdAsync(brandSliderPutDto.Id, false);
        BrandSlider brandSlider = _mapper.Map<BrandSlider>(brandSliderPutDto);
        if (brandSliderPutDto.Image != null && brandSliderPutDto.Image.Length > 0)
        {
            brandSlider.ImageURL = await _fileService.SaveFileAsync(
                brandSliderPutDto.Image,
                _webHostEnvironment.WebRootPath,
                new[] { ".png", ".jpg", ".jpeg" });
        }
        else
        {
            brandSlider.ImageURL = oldBrandSlider.ImageURL;
        }
        _brandSliderWriteRepository.Update(brandSlider);

        var result = await _brandSliderWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("BrandSlider not updated");
        }
    }
}