using FoodMartMono.Services.TrendProductService;
using Microsoft.AspNetCore.Mvc;

namespace FoodMartMono.ViewComponents
{
    public class _DefaultPhoneNewsComponentPartial:ViewComponent
    {        private readonly ITrendProductService _trendProductService;

        public _DefaultPhoneNewsComponentPartial(ITrendProductService trendProductService)
        {
            _trendProductService = trendProductService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        { var value = await _trendProductService.GetTrendProductsAsync();
            return View(value);
        }   
    }
}
