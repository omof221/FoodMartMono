using FoodMartMono.Services.DiscountService;
using Microsoft.AspNetCore.Mvc;

namespace FoodMartMono.ViewComponents
{
    public class _DefaultDownTrendProductComponentPartial:ViewComponent
    { private readonly IDiscountService _discountService;

        public _DefaultDownTrendProductComponentPartial(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        { var value = await _discountService.GetResultDiscountAsync();
            return View(value);
        }
    }
}
