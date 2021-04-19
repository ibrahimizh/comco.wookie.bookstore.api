using AutoMapper;

namespace comco.wookie.bookstore.api.Models
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Book,BookDTO>();
            CreateMap<BookDTO,Book>();
        }
    }
}