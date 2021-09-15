﻿using Bookstore.Core.Entities;
using Bookstore.SharedKernel;

namespace Bookstore.Core.AuthorAggregate.Events
{
    public class NewBookAdded : BaseDomainEvent
    {
        public Book Book { get; set; }
        public Author Author { get; set; }

        public NewBookAdded(Author author, Book book)
        {
            Author = author;
            Book = book;
        }
    }
}