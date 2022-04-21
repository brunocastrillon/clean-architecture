using Bookstore.Infra.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Infra.IoC
{
    public static class Identity
    {
        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            //services.AddIdentity<IdentityUser, IdentityRole>()
            //                  .AddEntityFrameworkStores<ApplicationDbContext>()
            //                  .AddDefaultTokenProviders();

            services.AddIdentityCore<IdentityUser>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
            }
            ).AddRoles<IdentityRole>()
             .AddRoleManager<RoleManager<IdentityRole>>()
             .AddSignInManager<SignInManager<IdentityUser>>()
             .AddRoleValidator<RoleValidator<IdentityRole>>()
             .AddEntityFrameworkStores<ApplicationDbContext>()
             .AddDefaultTokenProviders();

            return services;
        }
    }
}