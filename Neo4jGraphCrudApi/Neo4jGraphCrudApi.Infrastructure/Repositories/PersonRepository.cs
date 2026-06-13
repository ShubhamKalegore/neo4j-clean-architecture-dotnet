using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4j.Driver;
using Neo4jGraphCrudApi.Application.Interfaces;
using Neo4jGraphCrudApi.Domain.Entities;

namespace Neo4jGraphCrudApi.Infrastructure.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly IDriver _driver;

    public PersonRepository(IDriver driver)
    {
        _driver = driver;
    }

    public async Task CreateAsync(Person person)
    {
        await using var session = _driver.AsyncSession();

        await session.RunAsync(
        """
        CREATE (p:Person {
            id: $id,
            name: $name,
            age: $age
        })
        """,
        new
        {
            id = person.Id,
            name = person.Name,
            age = person.Age
        });
    }

    public async Task DeleteAsync(string id)
    {
        await using var session = _driver.AsyncSession();

        await session.RunAsync(
        """
        MATCH (p:Person {id: $id})
        DELETE p
        """,
        new
        {
            id
        });
    }

    public async Task<List<Person>> GetAllAsync()
    {
        var persons = new List<Person>();

        await using var session = _driver.AsyncSession();

        var result = await session.RunAsync(
            "MATCH (p:Person) RETURN p");

        await result.ForEachAsync(record =>
        {
            var node = record["p"].As<INode>();

            persons.Add(new Person
            {
                Id = node["id"].As<string>(),
                Name = node["name"].As<string>(),
                Age = node["age"].As<int>()
            });
        });

        return persons;
    }

    public async Task<Person?> GetByIdAsync(string id)
    {
        await using var session = _driver.AsyncSession();

        var result = await session.RunAsync(
        """
        MATCH (p:Person {id: $id})
        RETURN p
        """,
        new
        {
            id
        });

        if (!await result.FetchAsync())
        {
            return null;
        }

        var node = result.Current["p"].As<INode>();

        return new Person
        {
            Id = node["id"].As<string>(),
            Name = node["name"].As<string>(),
            Age = node["age"].As<int>()
        };
    }

    public async Task UpdateAsync(Person person)
    {
        await using var session = _driver.AsyncSession();

        await session.RunAsync(
            """
        MATCH (p:Person {id: $id})
        SET p.name = $name,
            p.age = $age
        """,
        new
        {
            id = person.Id,
            name = person.Name,
            age = person.Age
        });
    }
}
