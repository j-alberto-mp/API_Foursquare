using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace APIFoursquare.Services
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Configurar AutoMapper
        /// </summary>
        /// <param name="services"></param>
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}