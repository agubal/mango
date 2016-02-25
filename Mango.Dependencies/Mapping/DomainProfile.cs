using AutoMapper;
using Mango.Entities.Domain;
using Mango.Entities.Models;

namespace Mango.Dependencies.Mapping
{
    public class DomainProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Client, ClientModel>().ReverseMap();
            Mapper.CreateMap<Technology, TechnologyModel>().ReverseMap();
            Mapper.CreateMap<Service, ServiceModel>().ReverseMap();
            Mapper.CreateMap<Message, MessageModel>().ReverseMap();
        }
    }
}
