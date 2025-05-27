using Microsoft.AspNetCore.Mvc;

namespace FoodMartMono.Dtos.CategoryDtos
{
    public class UpdateCategoryDto
    {  
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string IconUrl { get; set; }
    }
}




