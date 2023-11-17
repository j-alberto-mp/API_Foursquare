using APIFoursquare.Repository.Context;
using APIFoursquare.Repository.Implementation;
using APIFoursquare.Repository.Interface;
using APIFoursquare.Services.Implementation;
using APIFoursquare.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace APIFoursquare.Test
{
    public static class Helper
    {
        private static IServiceProvider ServiceProvider()
        {
            var services = new ServiceCollection();

            //services.AddDbContext<ApiFoursquareDbContext>(options =>
            //   options.UseSqlServer(configuration.GetConnectionString("DbConnection"))
            //);

            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IFoursquareService, FoursquareService>();

            return services.BuildServiceProvider();
        }

        public static T GetRequiredService<T>()
        {
            var serviceProvider = ServiceProvider();

            return serviceProvider.GetRequiredService<T>();
        }
    }
}