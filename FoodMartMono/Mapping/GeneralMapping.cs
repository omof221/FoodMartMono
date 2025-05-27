using AutoMapper;
using FoodMartMono.Dtos.CategoryDtos;
using FoodMartMono.Dtos.CustomerDto;
using FoodMartMono.Dtos.DiscountsDto;
using FoodMartMono.Dtos.ProductDto;
using FoodMartMono.Dtos.TrendProductDto;
using FoodMartMono.Entities;

namespace FoodMartMono.Mapping
{
    public class GeneralMapping: Profile
    {
        public GeneralMapping()
        {
          CreateMap<Category,ResultCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategorybyIdDto>().ReverseMap();  
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();  
            CreateMap<Category, CreateCategoryDto>().ReverseMap();  
            
            CreateMap<Product, ResultProductDto>().ReverseMap();  
            CreateMap<Product, UpdateProductDto>().ReverseMap();  
            CreateMap<Product, CreateProductDto>().ReverseMap();  
            CreateMap<Product, GetProductByIdDto>().ReverseMap();  
            
            CreateMap<Customer, ResultCustomerDto>().ReverseMap();  
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();  
            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();  
            CreateMap<Customer, GetCustomerByIdDto>().ReverseMap();  
            
            CreateMap<Discount, GetDiscountByIdDto>().ReverseMap();  
            CreateMap<Discount, UpdateDiscountDto>().ReverseMap();  
            CreateMap<Discount, CreateDiscountDto>().ReverseMap();  
            CreateMap<Discount, ResultDiscountDto>().ReverseMap();  
            
            CreateMap<TrendProduct, ResultTrendProductDto>().ReverseMap();  
            CreateMap<TrendProduct, CreateTrendProductDto>().ReverseMap();  
            CreateMap<TrendProduct, UpdateTrendProductDto>().ReverseMap();  
            CreateMap<TrendProduct, GetTrendProductByIdDto>().ReverseMap();  

            

        }
    }   
    
    }

