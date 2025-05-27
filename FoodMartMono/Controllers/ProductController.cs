using FoodMartMono.Services.CategoryServices;
using FoodMartMono.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FoodMartMono.Dtos.ProductDto;
using AutoMapper.Configuration.Annotations;
using FoodMartMono.Dtos.CategoryDtos;
using FoodMartMono.Entities;
namespace FoodMartMono.Controllers
{
    public class ProductController : Controller
    { private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> ProductList()
        { var value = await _productService.GetResultProductAsync();    
            var category = await _categoryService.GetCategoryAsync();
        
            ViewBag.c=category;
            return View(value);
      

        }
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {  var category = await _categoryService.GetCategoryAsync();        
            ViewBag.v = category.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId
            });
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            createProductDto.Status = true;

        

            await _productService.CreateProoductAsync(createProductDto);
            return RedirectToAction("ProductList");
        }
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("ProductList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            var values = await _productService.GetProductByIdAsync(id);
            var category = await _categoryService.GetCategoryAsync();
            ViewBag.v = category.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId
            });
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return RedirectToAction("ProductList");
        }


        

    }
}
