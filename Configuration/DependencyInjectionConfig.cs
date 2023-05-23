using Microsoft.EntityFrameworkCore;
using products_categories.Application;
using products_categories.Data;
using products_categories.Domain.Repositories;
using products_categories.Infrastructure;

namespace products_categories.Configuration
{
    public class DependencyInjectionConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<CategoryService>();
            services.AddScoped<ProductService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "products_categories", Version = "v1" });
            });
        }

    }
}