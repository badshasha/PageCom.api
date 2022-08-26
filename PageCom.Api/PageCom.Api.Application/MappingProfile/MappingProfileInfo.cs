using AutoMapper;
using PageCom.Api.Application.DTO.BookDTO;
using PageCome.Api.Demain;

namespace PageCom.Api.Application.MappingProfile;

public class MappingProfileInfo : Profile
{
    public MappingProfileInfo()
    {
        CreateMap<Book, BookViewDTO>().ReverseMap();
    }
}