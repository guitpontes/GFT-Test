using GFTTest.Application.OrderApplication.Services;
using GFTTest.Application.OrderApplication.Services.Interfaces;
using GFTTest.Domain.Orders.Entities;
using GFTTest.Domain.Orders.Interfaces;
using GFTTest.Domain.Orders.Services;
using GFTTest.Domain.Orders.Services.Interfaces;
using GFTTest.Infra.OrderRepository;
using Microsoft.Extensions.DependencyInjection;

namespace GFTTest.IoC
{
    public class NativeInjector
    {
        public static void Setup(IServiceCollection services)
        {
            RegisterServices(services);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IOrderAppService, OrderAppService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();

        }
    }
}