using FoodMartMono.Dtos.TrendProductDto;
using FoodMartMono.Services.TrendProductService;
using Microsoft.AspNetCore.Mvc;

namespace FoodMartMono.Controllers
{
    public class TrendProductController : Controller
    { private readonly ITrendProductService _trendProductService;

        public TrendProductController(ITrendProductService trendProductService)
        {
            _trendProductService = trendProductService;
        }

        public async Task<IActionResult> TrendProductList()
        {
            var values = await _trendProductService.GetTrendProductsAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateTrendProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTrendProduct(CreateTrendProductDto createTrendProductDto)
        {
            await _trendProductService.CreateTrendProductAsync(createTrendProductDto);
            return RedirectToAction("TrendProductList");
        }
        public async Task<IActionResult> DeleteTrendProduct(string id)
        {
            await _trendProductService.DeleteTrendProductAsync(id);
            return RedirectToAction("TrendProductList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTrendProduct(string id)
        {
            var values = await _trendProductService.GetTrendProductByIdAsync(id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTrendProduct(UpdateTrendProductDto updateTrendProductDto)
        {
            await _trendProductService.UpdateTrendProductAsync(updateTrendProductDto);
            return RedirectToAction("TrendProductList");
        }
       
    }
}
