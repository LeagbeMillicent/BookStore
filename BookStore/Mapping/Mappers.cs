using AutoMapper;
using Books.Application.DTOs;
using Books.Domain;

namespace BookStore.Mapping
{
    public class Mappers : Profile
    {
        public Mappers() 
        {

            CreateMap<Book, CreateDTO>().ReverseMap();

            CreateMap<Book, ReadBookDTO>().ReverseMap();

            CreateMap<Book, UpdateDTO>().ReverseMap();

        }
    }
}
