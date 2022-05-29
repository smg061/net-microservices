using Catalog.API.Data;
using Catalog.API.Repositories;
using Catalog.API.Services.Repositories;
using Microsoft.OpenApi.Models;

namespace Catalog.API.Extensions
{
    public static class ConfigureServices
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Catalog.API", Version = "v1" });
            });
            services.AddEndpointsApiExplorer();
            services.AddScoped<ICatalogContext, CatalogContext>();
            services.AddScoped<IProductRepository, ProductRepository>();

        }
    }
}
