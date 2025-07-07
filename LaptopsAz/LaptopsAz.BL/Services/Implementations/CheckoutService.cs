using AutoMapper;
using LaptopsAz.BL.DTOs.CheckoutDtos;
using LaptopsAz.BL.Services.Abstractions;
using LaptopsAz.Core.Models;
using LaptopsAz.DL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace LaptopsAz.BL.Services.Implementations;

public class CheckoutService : ICheckoutService
{
    private readonly ICheckoutReadRepository _checkoutReadRepository;
    private readonly ICheckoutWriteRepository _checkoutWriteRepository;
    private readonly IMapper _mapper;
    
    public CheckoutService(ICheckoutReadRepository checkoutReadRepository, ICheckoutWriteRepository checkoutWriteRepository, IMapper mapper)
    {
        _checkoutReadRepository = checkoutReadRepository;
        _checkoutWriteRepository = checkoutWriteRepository;
        _mapper = mapper;
    }

    public async Task CreateCheckoutAsync(CheckoutPostDto checkoutPostDto)
    {
        Checkout checkout = _mapper.Map<Checkout>(checkoutPostDto);
        checkout.CreatedAt = DateTime.UtcNow.AddHours(4);
        await _checkoutWriteRepository.CreateAsync(checkout);
        var result = await _checkoutWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("Checkout not created");
        }
    }

    public async Task DeleteCheckoutAsync(Guid id)
    {
        if (!await _checkoutReadRepository.IsExist(id)) throw new Exception("Checkout not found");
        Checkout checkout = await _checkoutReadRepository.GetByIdAsync(id) ?? throw new Exception("Checkout not found");
        _checkoutWriteRepository.Delete(checkout);
        
        var result = await _checkoutWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("Checkout not created");
        }
        
    }

    public async Task<ICollection<CheckoutGetDto>> GetAllActiveCheckout(int size = 10, int page = 0)
    {
        ICollection<Checkout> checkouts = await _checkoutReadRepository.GetAllByCondition(c => !c.IsDeleted, page, size).ToListAsync();
        return _mapper.Map<ICollection<CheckoutGetDto>>(checkouts);
    }

    public async Task<ICollection<CheckoutGetDto>> GetAllSoftDeletedCheckout(int size = 10, int page = 0)
    {
        ICollection<Checkout> checkouts = await _checkoutReadRepository.GetAllByCondition(c => c.IsDeleted, page, size).ToListAsync();
        return _mapper.Map<ICollection<CheckoutGetDto>>(checkouts);
    }

    public async Task<CheckoutGetDto> GetByIdCheckoutAsync(Guid id)
    {
        if (!await _checkoutReadRepository.IsExist(id)) throw new Exception("Checkout not found");
        Checkout checkout = await _checkoutReadRepository.GetByIdAsync(id) ?? throw new Exception("Checkout not found");
        return _mapper.Map<CheckoutGetDto>(checkout);
    }

    public async Task RestoreCheckoutAsync(Guid id)
    {
        if (!await _checkoutReadRepository.IsExist(id)) throw new Exception("Checkout not found");
        Checkout checkout = await _checkoutReadRepository.GetOneByCondition(c => c.Id == id && c.IsDeleted, false) ?? throw new Exception("Checkout not found");
        checkout.IsDeleted = false;
        _checkoutWriteRepository.Update(checkout);

        var result = await _checkoutWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("Checkout not created");
        }
    }

    public async Task SoftDeleteCheckoutAsync(Guid id)
    {
        if (!await _checkoutReadRepository.IsExist(id)) throw new Exception("Checkout not found");
        Checkout checkout = await _checkoutReadRepository.GetOneByCondition(c => c.Id == id && !c.IsDeleted, false) ?? throw new Exception("Checkout not found");
        checkout.IsDeleted = true;
        _checkoutWriteRepository.Update(checkout);

        var result = await _checkoutWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("Checkout not created");
        }
    }

    public async Task UpdateCheckoutAsync(CheckoutPutDto checkoutPutDto)
    {
        Checkout oldCheckout = await _checkoutReadRepository.GetByIdAsync(checkoutPutDto.Id, false);
        Checkout checkout = _mapper.Map<Checkout>(checkoutPutDto);
        checkout.CreatedAt = oldCheckout.CreatedAt;
        _checkoutWriteRepository.Update(checkout);
        var result = await _checkoutWriteRepository.SaveChangesAsync();
        if (result == 0)
        {
            throw new Exception("Checkout not created");
        }
    }
}