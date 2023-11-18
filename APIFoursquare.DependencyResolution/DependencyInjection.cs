using APIFoursquare.Repository.Context;
using APIFoursquare.Repository.Implementation;
using APIFoursquare.Repository.Interface;
using APIFoursquare.Services;
using APIFoursquare.Services.Implementation;
using APIFoursquare.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace APIFoursquare.DependencyResolution
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Configurar los DbContext
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApiFoursquareDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DbConnection"))
           );
        }

        /// <summary>
        /// Inyectar los servicios
        /// </summary>
        /// <param name="services"></param>
        public static void AddPersistence(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<IFoursquareService, FoursquareService>();
            services.AddTransient<ICategoriaService, CategoriaService>();
            services.AddTransient<ILugarService, LugarService>();
        }

        /// <summary>
        /// Configurar AutoMapper
        /// </summary>
        /// <param name="services"></param>
        public static void AddAppLayer(this IServiceCollection services)
        {
            services.AddApplicationLayer();
        }
    }
}