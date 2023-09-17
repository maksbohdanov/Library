using Application.Models.DTOs;
using Application.Models.Requests;
using AutoMapper;
using Domain.Entities;

namespace Application.Utilities.Mapping
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Book, BookDTO>().ReverseMap();

            CreateMap<BookReq, Book>();
        }
    }
}
