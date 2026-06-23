using Ecom_lib.Base;
using Ecom_lib.Base;
using Ecom_udemy.Services;
using ECom_udemy.Base;
using ECom_udemy.Services.Auth;
using ECom_udemy.Services.Payments;
using ECom_udemy.Validation.Idintity;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Forms.Mapping;
using Microsoft.Extensions.DependencyModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using XAct.Validation;
using AuthenticationService = ECom_udemy.Services.Auth.AuthenticationService;
using IAuthenticationService = ECom_udemy.Base.IAuthenticationService;

namespace ECom_udemy.Classes
{
    public static class SrvContiner
    {
        public static IServiceCollection AddInjectionOptionApi(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MappingConfig>();
            });
            services.AddScoped<IProductService, ProductServices>();
            services.AddScoped<ICategoryService,CategoryServices>();
            //بدلاً من كتابة سطر تسجيل منفصل لكل كلاس فحص(Validator) بتعمله في مشروعك يدويًا،
            //السطر ده بيستخدم كلاس CreateUserValidator كـ "مرشد" ليعرف مكان المشروع(الـ Assembly)، ثم يقوم تلقائيًا باللف والتفتيش داخل المشروع بالكامل،
            //ويقوم بتسجيل أي كلاس فحص يجده وارثاً من مكتبة
            //FluentValidation داخل الـ Dependency Injection دفعة واحدة وبسطر واحد!
            services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IValidationServices, ValidationServices>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentMethodService, PaymentMethodService>();
            services.AddScoped<ICartservices, ECom_udemy.Services.CartService>();

            return services;
        }
    }
}
 
