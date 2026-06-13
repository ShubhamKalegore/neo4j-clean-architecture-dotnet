using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4jGraphCrudApi.Application.DTOs;

namespace Neo4jGraphCrudApi.Application.Interfaces;

public interface IPersonService
{
    Task CreateAsync(CreatePersonDto dto);

    Task<List<PersonDto>> GetAllAsync();

    Task<PersonDto?> GetByIdAsync(string id);

    Task UpdateAsync(PersonDto dto);

    Task DeleteAsync(string id);
}