using AutoMapper;
using LaptopsAz.BL.DTOs.ReviewDtos;
using LaptopsAz.BL.Services.Abstractions;
using LaptopsAz.Core.Models;
using LaptopsAz.DL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace LaptopsAz.BL.Services.Implementations;

public class ReviewService : IReviewService
{
    private readonly IReviewReadRepository _reviewReadRepository;
    private readonly IReviewWriteRepository _reviewWriteRepository;
    private readonly IMapper _mapper;
    
    public ReviewService(IReviewReadRepository reviewReadRepository, IReviewWriteRepository reviewWriteRepository, IMapper mapper)
    {
        _reviewReadRepository = reviewReadRepository;
        _reviewWriteRepository = reviewWriteRepository;
        _mapper = mapper;
    }

    public async Task CreateReviewAsync(ReviewPostDto reviewPostDto)
    {
        Review review = _mapper.Map<Review>(reviewPostDto);
        review.CreatedAt = DateTime.UtcNow.AddHours(4);
        await _reviewWriteRepository.CreateAsync(review);
        var result = await _reviewWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("Review not created");
        }
    }

    public async Task DeleteReviewAsync(Guid id)
    {
        if (!await _reviewReadRepository.IsExist(id)) throw new Exception("Review not found");
        Review review = await _reviewReadRepository.GetByIdAsync(id) ?? throw new Exception("Review not found");
        _reviewWriteRepository.Delete(review);

        var result = await _reviewWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("Review not created");
        }
    }

    public async Task<ICollection<ReviewGetDto>> GetAllActiveReview(int size = 10, int page = 0)
    {
        ICollection<Review> reviews = await _reviewReadRepository.GetAllByCondition(c => !c.IsDeleted, page, size).ToListAsync();
        return _mapper.Map<ICollection<ReviewGetDto>>(reviews);
    }

    public async Task<ICollection<ReviewGetDto>> GetAllSoftDeletedReview(int size = 10, int page = 0)
    {
        ICollection<Review> reviews = await _reviewReadRepository.GetAllByCondition(c => c.IsDeleted, page, size).ToListAsync();
        return _mapper.Map<ICollection<ReviewGetDto>>(reviews);
    }

    public async Task<ReviewGetDto> GetByIdReviewAsync(Guid id)
    {
        if (!await _reviewReadRepository.IsExist(id)) throw new Exception("Review not found");
        Review review = await _reviewReadRepository.GetByIdAsync(id) ?? throw new Exception("Review not found");
        return _mapper.Map<ReviewGetDto>(review);
    }

    public async Task<ICollection<ReviewGetDto>> GetByProductIdReviewsAsync(Guid productId)
    {
        ICollection<Review> photos = await _reviewReadRepository.GetAllByCondition(p => p.ProductID == productId && !p.IsDeleted).ToListAsync();
        return _mapper.Map<ICollection<ReviewGetDto>>(photos);
    }

    public async Task RestoreReviewAsync(Guid id)
    {
        if (!await _reviewReadRepository.IsExist(id)) throw new Exception("Review not found");
        Review review = await _reviewReadRepository.GetOneByCondition(c => c.Id == id && c.IsDeleted, false) ?? throw new Exception("Review not found");
        review.IsDeleted = false;
        _reviewWriteRepository.Update(review);

        var result = await _reviewWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("Review not created");
        }
    }

    public async Task SoftDeleteReviewAsync(Guid id)
    {
        if (!await _reviewReadRepository.IsExist(id)) throw new Exception("Review not found");
        Review review = await _reviewReadRepository.GetOneByCondition(c => c.Id == id && !c.IsDeleted, false) ?? throw new Exception("Review not found");
        review.IsDeleted = true;
        _reviewWriteRepository.Update(review);

        var result = await _reviewWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("Review not created");
        }
    }

    public async Task UpdateReviewAsync(ReviewPutDto reviewPutDto)
    {
        Review review = _mapper.Map<Review>(reviewPutDto);
        _reviewWriteRepository.Update(review);

        var result = await _reviewWriteRepository.SaveChangesAsync();

        if (result == 0)
        {
            throw new Exception("Review not created");
        }
    }
}