using Microsoft.AspNetCore.Mvc;

namespace FoodMartMono.ViewComponents
{
    public class _DefaultDiscountComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}