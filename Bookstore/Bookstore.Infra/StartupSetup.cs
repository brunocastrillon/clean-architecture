using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Infra
{
    public static class StartupSetup
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString) => services.AddDbContext<DbContext>(options => options.UseSqlite(connectionString)); // will be created in web project root
    }
}