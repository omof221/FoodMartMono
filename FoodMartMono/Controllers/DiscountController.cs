using FoodMartMono.Dtos.DiscountsDto;
using FoodMartMono.Services.CategoryServices;
using FoodMartMono.Services.DiscountService;
using Microsoft.AspNetCore.Mvc;

namespace FoodMartMono.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly ICategoryService _categoryService;
        public DiscountController(IDiscountService discountService, ICategoryService categoryService)
        {
            _discountService = discountService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> DiscountList()
        {
            var value = await _discountService.GetResultDiscountAsync();
            return View(value);
        }
        [HttpGet]
        public async Task<IActionResult> CreateDiscount()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            await _discountService.CreateDiscountAsync(createDiscountDto);
            return RedirectToAction("DiscountList");
        }
        public async Task<IActionResult> DeleteDiscount(string id)
        {
            await _discountService.DeleteDiscountAsync(id);
            return RedirectToAction("DiscountList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateDiscount(string id)
        {
            var values = await _discountService.GetDiscountByIdAsync(id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            await _discountService.UpdateDiscountAsync(updateDiscountDto);
            return RedirectToAction("DiscountList");
        }
    }
}
