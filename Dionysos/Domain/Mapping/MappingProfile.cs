using AutoMapper;
using DTO;
using Infrastructure.DataBase.Tables;
using Messages;

namespace Domain.Mapping
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
