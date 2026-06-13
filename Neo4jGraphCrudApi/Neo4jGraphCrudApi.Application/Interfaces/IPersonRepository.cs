using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4jGraphCrudApi.Domain.Entities;

namespace Neo4jGraphCrudApi.Application.Interfaces;
public interface IPersonRepository
{
    Task CreateAsync(Person person);

    Task<List<Person>> GetAllAsync();

    Task<Person?> GetByIdAsync(string id);

    Task UpdateAsync(Person person);

    Task DeleteAsync(string id);
}