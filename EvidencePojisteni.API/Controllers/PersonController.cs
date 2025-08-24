using EvidencePojisteni.API.Services;
using EvidencePojisteniDto;
using Microsoft.AspNetCore.Mvc;

namespace EvidencePojisteni.API.Controllers;

[Route("Person")]
[ApiController]
public class PersonController(PersonService service) : ControllerBase
{
    /// <summary>
    /// Gets a specific person record by their ID.
    /// </summary>
    [HttpGet("{PersonId:Guid}")]
    public async Task<ActionResult<UpdatePersonDto>> Get([FromRoute] Guid PersonId)
    {
        var person = await service.Get(PersonId);
        if (person is null)
            return NotFound();

        var dto = new UpdatePersonDto
        {
            FirstName = person.FirstName,
            LastName = person.LastName,
            Phone = person.Phone,
            Age = person.Age
        };
        return Ok(dto);
    }

    /// <summary>
    /// Gets a list of all person records.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<UpdatePersonDto[]>> GetList()
    {
        var allPeople = await service.GetList();
        var dtos = allPeople.Select(person => new UpdatePersonDto
        {
            FirstName = person.FirstName,
            LastName = person.LastName,
            Phone = person.Phone,
            Age = person.Age
        }).ToArray();
        return Ok(dtos);
    }

    /// <summary>
    /// Creates a new person record.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> New([FromBody] NewPersonDto personDto)
    {
        var person = new Person
        {
            PersonId = Guid.NewGuid(),
            FirstName = personDto.FirstName,
            LastName = personDto.LastName,
            Phone = personDto.Phone,
            Age = personDto.Age
        };

        await service.Create(person);
        return CreatedAtAction(nameof(Get), new { PersonId = person.PersonId }, null);
    }

    /// <summary>
    /// Deletes a person record by their ID.
    /// </summary>
    [HttpDelete("{PersonId:Guid}")]
    public Task<ActionResult> Delete([FromRoute] Guid PersonId)
    {
        var result = service.Delete(PersonId);

        if (result == "Deleted")
        {
            return Task.FromResult<ActionResult>(Ok());
        }
        return Task.FromResult<ActionResult>(NotFound());
    }

    /// <summary>
    /// Updates a person record by their ID.
    /// </summary>
    [HttpPut("{PersonId:Guid}")]
    public async Task<ActionResult> Update([FromRoute] Guid personId, [FromBody] UpdatePersonDto personDto)
    {
        var existingPerson = await service.Get(personId);
        if (existingPerson is null)
        {
            return NotFound();
        }

        existingPerson.FirstName = personDto.FirstName;
        existingPerson.LastName = personDto.LastName;
        existingPerson.Phone = personDto.Phone;
        existingPerson.Age = personDto.Age;

        await service.Update(personId, existingPerson);
        return NoContent();
    }
}
