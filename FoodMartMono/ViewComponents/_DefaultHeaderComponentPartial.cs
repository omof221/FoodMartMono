using Microsoft.AspNetCore.Mvc;

namespace FoodMartMono.ViewComponents
{
    public class _DefaultHeaderComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
