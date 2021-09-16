using System.Collections.Generic;

namespace Bookstore.API.DTO
{
    public class Author : CreateAuthor
    {
        public int Id { get; set; }
        public List<Book> Books = new();
    }

    public class CreateAuthor
    {
        public string Name { get; set; }
    }
}