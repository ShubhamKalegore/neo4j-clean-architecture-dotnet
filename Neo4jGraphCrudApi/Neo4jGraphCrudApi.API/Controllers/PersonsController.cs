using Microsoft.AspNetCore.Mvc;
using Neo4jGraphCrudApi.Application.DTOs;
using Neo4jGraphCrudApi.Application.Interfaces;

namespace Neo4jGraphCrudApi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonsController : ControllerBase
{
    private readonly IPersonService _personService;

    public PersonsController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpGet]
    public async Task<ActionResult<List<PersonDto>>> GetAll()
    {
        var persons = await _personService.GetAllAsync();

        return Ok(persons);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PersonDto>> GetById(string id)
    {
        var person = await _personService.GetByIdAsync(id);

        return person == null ? NotFound() : Ok(person);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePersonDto dto)
    {
        await _personService.CreateAsync(dto);

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, PersonDto dto)
    {
        if (!string.Equals(id, dto.Id, StringComparison.Ordinal))
        {
            return BadRequest("Route id must match person id.");
        }

        await _personService.UpdateAsync(dto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _personService.DeleteAsync(id);

        return NoContent();
    }
}
