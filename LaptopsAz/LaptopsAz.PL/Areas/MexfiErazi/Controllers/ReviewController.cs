using AutoMapper;
using LaptopsAz.BL.DTOs.ReviewDtos;
using LaptopsAz.BL.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LaptopsAz.PL.Areas.MexfiErazi.Controllers
{
    [Area("MexfiErazi")]
    [Authorize]
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ReviewController(IMapper mapper, IReviewService ReviewService, IProductService productService)
        {
            _mapper = mapper;
            _reviewService = ReviewService;
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                ICollection<ReviewGetDto> Reviews = await _reviewService.GetAllActiveReview(10000);
                return View(Reviews);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }
        
        [HttpGet]
        public async Task<IActionResult> Trash()
        {
            try
            {
                ICollection<ReviewGetDto> ReviewGetDto = await _reviewService.GetAllSoftDeletedReview(10000);
                return View(ReviewGetDto);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }
        
        [HttpGet]
        public async Task<IActionResult> SoftDelete(Guid id)
        {
            try
            {
                await _reviewService.SoftDeleteReviewAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }
        
        [HttpGet]
        public async Task<IActionResult> Restore(Guid id)
        {
            try
            {
                await _reviewService.RestoreReviewAsync(id);
                return RedirectToAction("Trash");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }
        
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _reviewService.DeleteReviewAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}
