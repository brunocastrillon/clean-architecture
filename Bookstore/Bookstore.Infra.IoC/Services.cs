using Bookstore.Core.Application.Services.Author;
using Bookstore.Core.Application.Services.Book;
using Bookstore.Core.Application.Services.Category;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Infra.IoC
{
    public static class Services
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}