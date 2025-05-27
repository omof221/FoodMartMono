using Microsoft.AspNetCore.Mvc;

namespace FoodMartMono.ViewComponents
{
    public class _DefaultMyCartComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
