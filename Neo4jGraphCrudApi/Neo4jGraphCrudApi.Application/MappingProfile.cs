using AutoMapper;
using Neo4jGraphCrudApi.Application.DTOs;
using Neo4jGraphCrudApi.Domain.Entities;

namespace Neo4jGraphCrudApi.Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Person, PersonDto>();
        CreateMap<PersonDto, Person>();
        CreateMap<CreatePersonDto, Person>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}
