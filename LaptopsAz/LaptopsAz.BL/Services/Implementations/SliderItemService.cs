using AutoMapper;
using LaptopsAz.BL.DTOs.SliderItemDtos;
using LaptopsAz.BL.ExternalServices.Abstractions;
using LaptopsAz.BL.Services.Abstractions;
using LaptopsAz.Core.Models;
using LaptopsAz.DL.Repositories.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace LaptopsAz.BL.Services.Implementations;

public class SliderItemService : ISliderItemService
{
    private readonly ISliderItemReadRepository _sliderItemReadRepository;
    private readonly ISliderItemWriteRepository _sliderItemWriteRepository;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;
    IWebHostEnvironment _webHostEnvironment;
    
    public SliderItemService(ISliderItemReadRepository sliderItemReadRepository, ISliderItemWriteRepository sliderItemWriteRepository, IMapper mapper, IFileService fileService, IWebHostEnvironment webHostEnvironment)
    {
        _sliderItemReadRepository = sliderItemReadRepository;
        _sliderItemWriteRepository = sliderItemWriteRepository;
        _mapper = mapper;
        _fileService = fileService;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task CreateSliderItemAsync(SliderItemPostDto sliderItemPostDto)
    {
        SliderItem sliderItem = _mapper.Map<SliderItem>(sliderItemPostDto);
        sliderItem.CreatedAt = DateTime.UtcNow.AddHours(4);
        sliderItem.ImageURL = await _fileService.SaveFileAsync(sliderItemPostDto.Image, _webHostEnvironment.WebRootPath,new[] { ".png", ".jpg", ".jpeg" } );
        await _sliderItemWriteRepository.CreateAsync(sliderItem);
        var result = await _sliderItemWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("SliderItem not created");
        }
    }

    public async Task DeleteSliderItemAsync(Guid id)
    {
        if (!await _sliderItemReadRepository.IsExist(id)) throw new Exception("SliderItem not found");
        SliderItem sliderItem = await _sliderItemReadRepository.GetByIdAsync(id) ?? throw new Exception("SliderItem not found");
        _sliderItemWriteRepository.Delete(sliderItem);

        var result = await _sliderItemWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("SliderItem not created");
        }
    }

    public async Task<ICollection<SliderItemGetDto>> GetAllActiveSliderItem(int size = 10, int page = 0)
    {
        ICollection<SliderItem> sliderItems = await _sliderItemReadRepository.GetAllByCondition(c => !c.IsDeleted, page, size).ToListAsync();
        return _mapper.Map<ICollection<SliderItemGetDto>>(sliderItems);
    }

    public async Task<ICollection<SliderItemGetDto>> GetAllSoftDeletedSliderItem(int size = 10, int page = 0)
    {
        ICollection<SliderItem> sliderItems = await _sliderItemReadRepository.GetAllByCondition(c => c.IsDeleted, page, size).ToListAsync();
        return _mapper.Map<ICollection<SliderItemGetDto>>(sliderItems);
    }

    public async Task<SliderItemGetDto> GetByIdSliderItemAsync(Guid id)
    {
        if (!await _sliderItemReadRepository.IsExist(id)) throw new Exception("SliderItem not found");
        SliderItem sliderItem = await _sliderItemReadRepository.GetByIdAsync(id) ?? throw new Exception("SliderItem not found");
        return _mapper.Map<SliderItemGetDto>(sliderItem);
    }

    public async Task RestoreSliderItemAsync(Guid id)
    {
        if (!await _sliderItemReadRepository.IsExist(id)) throw new Exception("SliderItem not found");
        SliderItem sliderItem = await _sliderItemReadRepository.GetOneByCondition(c => c.Id == id && c.IsDeleted, false) ?? throw new Exception("SliderItem not found");
        sliderItem.IsDeleted = false;
        _sliderItemWriteRepository.Update(sliderItem);

        var result = await _sliderItemWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("SliderItem not created");
        }
    }

    public async Task SoftDeleteSliderItemAsync(Guid id)
    {
        if (!await _sliderItemReadRepository.IsExist(id)) throw new Exception("SliderItem not found");
        SliderItem sliderItem = await _sliderItemReadRepository.GetOneByCondition(c => c.Id == id && !c.IsDeleted, false) ?? throw new Exception("SliderItem not found");
        sliderItem.IsDeleted = true;
        _sliderItemWriteRepository.Update(sliderItem);

        var result = await _sliderItemWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("SliderItem not created");
        }
    }

    public async Task UpdateSliderItemAsync(SliderItemPutDto sliderItemPutDto)
    {
        SliderItem oldSliderItem = await _sliderItemReadRepository.GetByIdAsync(sliderItemPutDto.Id, false);
        SliderItem sliderItem = _mapper.Map<SliderItem>(sliderItemPutDto);
        if (sliderItemPutDto.Image != null && sliderItemPutDto.Image.Length > 0)
        {
            sliderItem.ImageURL = await _fileService.SaveFileAsync(
                sliderItemPutDto.Image,
                _webHostEnvironment.WebRootPath,
                new[] { ".png", ".jpg", ".jpeg" });
        }
        else
        {
            sliderItem.ImageURL = oldSliderItem.ImageURL;
        }
        _sliderItemWriteRepository.Update(sliderItem);

        var result = await _sliderItemWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("SliderItem not created");
        }
    }
}