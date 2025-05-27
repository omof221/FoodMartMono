using FoodMartMono.Dtos.ProductDto;
using FoodMartMono.Services.ProductServices;

using Microsoft.AspNetCore.Mvc;

namespace FoodMartMono.ViewComponents
{
    public class _DefaultBestSellingProductsComponentPartial:ViewComponent
    { private readonly IProductService _productService;

        public _DefaultBestSellingProductsComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        { var value = await _productService.GetResultProductAsync();

            if (value == null)
            {
                value = new List<ResultProductDto>();

            }

            var lowestProducts = value.OrderBy(x => x.ProductPrice).Take(6).ToList();  
            return View(lowestProducts);
        }
    }
}
