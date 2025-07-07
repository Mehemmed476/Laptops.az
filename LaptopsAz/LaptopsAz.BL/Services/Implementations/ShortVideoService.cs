using AutoMapper;
using LaptopsAz.BL.DTOs.ShortVideoDtos;
using LaptopsAz.BL.Services.Abstractions;
using LaptopsAz.Core.Models;
using LaptopsAz.DL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace LaptopsAz.BL.Services.Implementations;

public class ShortVideoService : IShortVideoService
{
    private readonly IShortVideoReadRepository _shortVideoReadRepository;
    private readonly IShortVideoWriteRepository _shortVideoWriteRepository;
    private readonly IMapper _mapper;


    public ShortVideoService(IShortVideoReadRepository shortVideoReadRepository, IShortVideoWriteRepository shortVideoWriteRepository, IMapper mapper)
    {
        _shortVideoReadRepository = shortVideoReadRepository;
        _shortVideoWriteRepository = shortVideoWriteRepository;
        _mapper = mapper;
    }

    public async Task CreateShortVideoAsync(ShortVideoPostDto shortVideoPostDto)
    {
        ShortVideo shortVideo = _mapper.Map<ShortVideo>(shortVideoPostDto);
        shortVideo.CreatedAt = DateTime.UtcNow.AddHours(4);
        await _shortVideoWriteRepository.CreateAsync(shortVideo);
        var result = await _shortVideoWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("ShortVideo not created");
        }
    }

    public async Task DeleteShortVideoAsync(Guid id)
    {
        if (!await _shortVideoReadRepository.IsExist(id)) throw new Exception("ShortVideo not found");
        ShortVideo shortVideo = await _shortVideoReadRepository.GetByIdAsync(id) ?? throw new Exception("ShortVideo not found");
        _shortVideoWriteRepository.Delete(shortVideo);

        var result = await _shortVideoWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("ShortVideo not created");
        }
    }

    public async Task<ICollection<ShortVideoGetDto>> GetAllActiveShortVideo(int size = 10, int page = 0)
    {
        ICollection<ShortVideo> shortVideos = await _shortVideoReadRepository.GetAllByCondition(c => !c.IsDeleted, page, size).ToListAsync();
        return _mapper.Map<ICollection<ShortVideoGetDto>>(shortVideos);
    }

    public async Task<ICollection<ShortVideoGetDto>> GetAllSoftDeletedShortVideo(int size = 10, int page = 0)
    {
        ICollection<ShortVideo> shortVideos = await _shortVideoReadRepository.GetAllByCondition(c => c.IsDeleted, page, size).ToListAsync();
        return _mapper.Map<ICollection<ShortVideoGetDto>>(shortVideos);
    }

    public async Task<ShortVideoGetDto> GetByIdShortVideoAsync(Guid id)
    {
        if (!await _shortVideoReadRepository.IsExist(id)) throw new Exception("ShortVideo not found");
        ShortVideo shortVideo = await _shortVideoReadRepository.GetByIdAsync(id) ?? throw new Exception("ShortVideo not found");
        return _mapper.Map<ShortVideoGetDto>(shortVideo);
    }

    public async Task RestoreShortVideoAsync(Guid id)
    {
        if (!await _shortVideoReadRepository.IsExist(id)) throw new Exception("ShortVideo not found");
        ShortVideo shortVideo = await _shortVideoReadRepository.GetOneByCondition(c => c.Id == id && c.IsDeleted, false) ?? throw new Exception("ShortVideo not found");
        shortVideo.IsDeleted = false;
        _shortVideoWriteRepository.Update(shortVideo);

        var result = await _shortVideoWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("ShortVideo not created");
        }
    }

    public async Task SoftDeleteShortVideoAsync(Guid id)
    {
        if (!await _shortVideoReadRepository.IsExist(id)) throw new Exception("ShortVideo not found");
        ShortVideo shortVideo = await _shortVideoReadRepository.GetOneByCondition(c => c.Id == id && !c.IsDeleted, false) ?? throw new Exception("ShortVideo not found");
        shortVideo.IsDeleted = true;
        _shortVideoWriteRepository.Update(shortVideo);

        var result = await _shortVideoWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("ShortVideo not created");
        }
    }

    public async Task UpdateShortVideoAsync(ShortVideoPutDto shortVideoPutDto)
    {
        ShortVideo oldShortVideo = await _shortVideoReadRepository.GetByIdAsync(shortVideoPutDto.Id, false);
        ShortVideo shortVideo = _mapper.Map<ShortVideo>(shortVideoPutDto);
        _shortVideoWriteRepository.Update(shortVideo);

        var result = await _shortVideoWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("ShortVideo not updated");
        }
    }
}