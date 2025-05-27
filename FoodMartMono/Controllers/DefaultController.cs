using Microsoft.AspNetCore.Mvc;

namespace FoodMartMono.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
