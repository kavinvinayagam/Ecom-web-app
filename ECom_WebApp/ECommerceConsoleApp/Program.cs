using ECommerceConsoleApp.Controller;
using ECommerceConsoleApp.Interface.Repositories;
using ECommerceConsoleApp.Interface.Services;
using ECommerceConsoleApp.Repositories;
using ECommerceConsoleApp.Service;
using Microsoft.Extensions.DependencyInjection;


namespace ECommerceConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();
            var app = serviceProvider.GetRequiredService<MainController>();
            app.MainMenu();
            
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<MainController>();
            services.AddTransient<CustomersController>();
            services.AddTransient<ProductController>();
            services.AddTransient<OrderController>();

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddScoped<IOrderService, OrderService>();
            services.AddTransient<IOrderRepository, OrderRepository>();

        }



    }
}
