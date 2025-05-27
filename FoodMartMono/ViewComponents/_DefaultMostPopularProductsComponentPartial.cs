using FoodMartMono.Services.CategoryServices;
using FoodMartMono.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace FoodMartMono.ViewComponents
{
    public class _DefaultMostPopularProductsComponentPartial:ViewComponent
    { private readonly IProductService _productService;

        public _DefaultMostPopularProductsComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        { var value = await _productService.GetResultProductAsync();    
             
            return View(value);
        }
    }
}
