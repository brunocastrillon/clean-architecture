using Bookstore.Core.AuthorAggregate;
using Bookstore.Core.Entities;
using Bookstore.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Bookstore.API
{
    public static class Seed
    {
        public static readonly Author _author = new Author("");
        public static readonly Book _book = new Book("", "");

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var dataContext = new DataBaseContext(serviceProvider.GetRequiredService<DbContextOptions<DataBaseContext>>(), null))
            {
                if (dataContext.Books.Any()) return;

                PopulateTestData(dataContext);
            }
        }

        public static void PopulateTestData(DataBaseContext context)
        {
            foreach (var item in context.Books)
            {
                context.Remove(item);
            }
            context.SaveChanges();

            _author.AddBook(_book);

            context.SaveChanges();
        }
    }
}