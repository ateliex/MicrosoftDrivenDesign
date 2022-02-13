using Ateliex.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Ateliex.Modules
{
    public static class DbModule
    {
        internal static IServiceCollection AddDbServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            //services.AddDbContext<AteliexDbContext>(options =>
            //    options.UseSqlServer(connectionString), ServiceLifetime.Singleton);

            services.AddDbContext<AteliexDbContext>(options =>
                options.UseSqlite(@"Data Source=Ateliex.db"), ServiceLifetime.Singleton);

            //

            //ServiceProvider = services.BuildServiceProvider();

            //

            //var connectionString = ConfigurationManager.ConnectionStrings["Atelie"].ToString();

            //var builder = new DbContextOptionsBuilder<AtelieDbContext>();

            //container.Register(() => new AtelieDbContext(builder.UseSqlite(connectionString).Options), Lifestyle.Singleton);

            //container.Register<AteliexDbContext>(Lifestyle.Singleton);

            //

            return services;
        }

        public static async Task EnsureDatabaseCreatedAsync(IServiceScopeFactory serviceScopeFactory)
        {
            using (var serviceScope = serviceScopeFactory.CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<AteliexDbContext>();

                await db.Database.EnsureCreatedAsync();

                await db.Database.MigrateAsync();
            }
        }
    }
}
