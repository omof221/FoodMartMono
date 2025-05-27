using Microsoft.AspNetCore.Mvc;

namespace FoodMartMono.ViewComponents
{
    public class _DefaultUpperCategoryComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}