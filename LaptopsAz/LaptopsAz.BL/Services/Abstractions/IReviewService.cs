using LaptopsAz.BL.DTOs.ReviewDtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaptopsAz.BL.Services.Abstractions;

public interface IReviewService
{
    Task CreateReviewAsync(ReviewPostDto dto);
    Task DeleteReviewAsync(Guid id);
    Task SoftDeleteReviewAsync(Guid id);
    Task RestoreReviewAsync(Guid id);
    Task UpdateReviewAsync(ReviewPutDto dto);
    Task<ICollection<ReviewGetDto>> GetAllActiveReview(int size = 10, int page = 0);
    Task<ICollection<ReviewGetDto>> GetAllSoftDeletedReview(int size = 10, int page = 0);
    Task<ReviewGetDto> GetByIdReviewAsync(Guid id);
    Task<ICollection<ReviewGetDto>> GetByProductIdReviewsAsync(Guid productId);
}