using Bookstore.Core.Entities;
using Bookstore.SharedKernel;
using Bookstore.SharedKernel.Interfaces;
using System.Collections.Generic;

namespace Bookstore.Core.AuthorAggregate.Author
{
    public class Author : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        private List<Book> _books = new List<Book>();
        public IEnumerable<Book> Books => _books.AsReadOnly();

        public Author(string name)
        {
            Name = name;
        }

        public void UpdateName(string newName)
        {
            Name = newName;
        }

        public void AddBook(Book newBook)
        {
            _books.Add(newBook);
        }
    }
}