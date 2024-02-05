using Application.Messages;
using AutoMapper;
using DTO;
using Infrastructure.DataBase.Tables;

namespace Application.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<RequestItalianRedWineDto, RequestItalianRedWine>();
            CreateMap<RequestItalianRedWine, Order>();
        }
    }
}
