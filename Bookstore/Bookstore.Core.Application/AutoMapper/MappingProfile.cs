using AutoMapper;
using Bookstore.Core.Application.DTO;
using Bookstore.Core.Domain.Entities;
using Bookstore.Core.Domain.Entities.Auth;

namespace Bookstore.Core.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}