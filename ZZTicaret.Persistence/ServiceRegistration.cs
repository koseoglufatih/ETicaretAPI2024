using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZTicaret.Application.Repositories;
using ZZTicaret.Application.Services;
using ZZTicaret.Domain;
using ZZTicaret.Persistence.Repositories;

namespace ZZTicaret.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection servicecollection, IConfiguration configuration = null)
        {

           
            servicecollection.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            servicecollection.AddScoped<IProductRepository,ProductRepository>();
            servicecollection.AddScoped<ICategoryRepository,CategoryRepository>();
            servicecollection.AddScoped<IOrderRepository,OrderRepository>();        
            servicecollection.AddScoped<IBasketRepository,BasketRepository>();
            servicecollection.AddScoped<IBasketItemRepository, BasketItemRepository>();
            servicecollection.AddTransient<IUserRepository, UserRepository>();

            servicecollection.AddScoped<IProductService,ProductService>();
            servicecollection.AddScoped<ICategoryService, CategoryService>();
            servicecollection.AddScoped<IOrderService, OrderService>();
            servicecollection.AddScoped<IBasketService, BasketService>();
            servicecollection.AddScoped<IUserService, UserService>();



        }
    }
}
