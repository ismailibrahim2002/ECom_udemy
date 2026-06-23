using AutoMapper;
using ECom_db.Entities;
using ECom_db.Entities.Identity;
using ECom_db.Entities.Payment;
using Ecom_lib.Dtos;
using Ecom_lib.Dtos.Cart;
using Ecom_lib.Dtos.Identity;
using Ecom_lib.Dtos.Paymants;

namespace ECom_udemy.Classes
{
    public class MappingConfig :Profile
    {
        public MappingConfig()
        {
            CreateMap<CategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<ProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<Product, GetProductDto>();
            CreateMap<Category, GetCategoryDto>();
            CreateMap<PaymentMethodDto, PaymentMethod>();
            CreateMap<PaymentMethod, PaymentMethodDto>();
            CreateMap<CreateUser, AppUser>();
            CreateMap<LogInUser, AppUser>();
            CreateMap<ProductHistoryDto, ProductHistory>();
        }
    }
}
