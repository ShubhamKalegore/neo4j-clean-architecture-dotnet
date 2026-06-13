using AutoMapper;
using Neo4jGraphCrudApi.Application.DTOs;
using Neo4jGraphCrudApi.Application.Interfaces;
using Neo4jGraphCrudApi.Domain.Entities;

namespace Neo4jGraphCrudApi.Application.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;

    public PersonService(IPersonRepository personRepository, IMapper mapper)
    {
        _personRepository = personRepository;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreatePersonDto dto)
    {
        var  person = _mapper.Map<Person>(dto);

        await _personRepository.CreateAsync(person);
    }

    public async Task<List<PersonDto>> GetAllAsync()
    {
        var persons = await _personRepository.GetAllAsync();

        return _mapper.Map<List<PersonDto>>(persons);
    }

    public async Task<PersonDto?> GetByIdAsync(string id)
    {
        var person = await _personRepository.GetByIdAsync(id);

        return person == null ? null : _mapper.Map<PersonDto>(person);
    }

    public async Task UpdateAsync(PersonDto dto)
    {
        var person = _mapper.Map<Person>(dto);

        await _personRepository.UpdateAsync(person);
    }

    public async Task DeleteAsync(string id)
    {
        await _personRepository.DeleteAsync(id);
    }
}
