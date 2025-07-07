using AutoMapper;
using LaptopsAz.BL.DTOs.NewstellerDtos;
using LaptopsAz.BL.Services.Abstractions;
using LaptopsAz.Core.Models;
using LaptopsAz.DL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace LaptopsAz.BL.Services.Implementations;

public class NewstellerService : INewstellerService
{
    private readonly INewstellerReadRepository _newstellerReadRepository;
    private readonly INewstellerWriteRepository _newstellerWriteRepository;
    private readonly IMapper _mapper;
    
    public NewstellerService(INewstellerReadRepository newstellerReadRepository, INewstellerWriteRepository newstellerWriteRepository, IMapper mapper)
    {
        _newstellerReadRepository = newstellerReadRepository;
        _newstellerWriteRepository = newstellerWriteRepository;
        _mapper = mapper;
    }

    public async Task CreateNewstellerAsync(NewstellerPostDto newstellerPostDto)
    {
        Newsteller newsteller = _mapper.Map<Newsteller>(newstellerPostDto);
        newsteller.CreatedAt = DateTime.UtcNow.AddHours(4);
        await _newstellerWriteRepository.CreateAsync(newsteller);
        var result = await _newstellerWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("Newsteller not created");
        }
    }

    public async Task DeleteNewstellerAsync(Guid id)
    {
        if (!await _newstellerReadRepository.IsExist(id)) throw new Exception("Newsteller not found");
        Newsteller newsteller = await _newstellerReadRepository.GetByIdAsync(id) ?? throw new Exception("Newsteller not found");
        _newstellerWriteRepository.Delete(newsteller);

        var result = await _newstellerWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("Newsteller not created");
        }
    }

    public async Task<ICollection<NewstellerGetDto>> GetAllActiveNewsteller(int size = 10, int page = 0)
    {
        ICollection<Newsteller> newstellers = await _newstellerReadRepository.GetAllByCondition(c => !c.IsDeleted, page, size).ToListAsync();
        return _mapper.Map<ICollection<NewstellerGetDto>>(newstellers);
    }

    public async Task<ICollection<NewstellerGetDto>> GetAllSoftDeletedNewsteller(int size = 10, int page = 0)
    {
        ICollection<Newsteller> newstellers = await _newstellerReadRepository.GetAllByCondition(c => c.IsDeleted, page, size).ToListAsync();
        return _mapper.Map<ICollection<NewstellerGetDto>>(newstellers);
    }

    public async Task<NewstellerGetDto> GetByIdNewstellerAsync(Guid id)
    {
        if (!await _newstellerReadRepository.IsExist(id)) throw new Exception("Newsteller not found");
        Newsteller newsteller = await _newstellerReadRepository.GetByIdAsync(id) ?? throw new Exception("Newsteller not found");
        return _mapper.Map<NewstellerGetDto>(newsteller);
    }

    public async Task RestoreNewstellerAsync(Guid id)
    {
        if (!await _newstellerReadRepository.IsExist(id)) throw new Exception("Newsteller not found");
        Newsteller newsteller = await _newstellerReadRepository.GetOneByCondition(c => c.Id == id && c.IsDeleted, false) ?? throw new Exception("Newsteller not found");
        newsteller.IsDeleted = false;
        _newstellerWriteRepository.Update(newsteller);

        var result = await _newstellerWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("Newsteller not created");
        }
    }

    public async Task SoftDeleteNewstellerAsync(Guid id)
    {
        if (!await _newstellerReadRepository.IsExist(id)) throw new Exception("Newsteller not found");
        Newsteller newsteller = await _newstellerReadRepository.GetOneByCondition(c => c.Id == id && !c.IsDeleted, false) ?? throw new Exception("Newsteller not found");
        newsteller.IsDeleted = true;
        _newstellerWriteRepository.Update(newsteller);

        var result = await _newstellerWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("Newsteller not created");
        }
    }

    public async Task UpdateNewstellerAsync(NewstellerPutDto newstellerPutDto)
    {
        Newsteller newsteller = _mapper.Map<Newsteller>(newstellerPutDto);
        _newstellerWriteRepository.Update(newsteller);

        var result = await _newstellerWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("Newsteller not created");
        }
    }
}