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
    public async Task<ActionResult<ListItemPersonDto>> Get([FromRoute] Guid PersonId)
    {
        var person = await service.Get(PersonId);
        if (person is null)
            return NotFound();

       
        var dto = person.GetListItem();
        return Ok(dto);
    }

    /// <summary>
    /// Gets a list of all person records.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<ListItemPersonDto[]>> GetList()
    {
        var allPeople = await service.GetList();
        // Service should provide the DTOs
        var dtos = allPeople.Select(p => p.GetListItem()).ToArray();
        return Ok(dtos);
    }

    /// <summary>
    /// Creates a new person record.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> New([FromBody] DetailPersonDto personDto)
    {
        var personId = await service.Create(personDto);
        return CreatedAtAction(nameof(Get), new { PersonId = personId }, null);
    }

    /// <summary>
    /// Deletes a person record by their ID.
    /// </summary>
    [HttpDelete("{PersonId:Guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid PersonId)
    {
        var deleted = await service.Delete(PersonId);
        if (deleted)
            return Ok();
        return NotFound();
    }

    /// <summary>
    /// Updates a person record by their ID.
    /// </summary>
    [HttpPut("{PersonId:Guid}")]
    public async Task<ActionResult> Update([FromRoute] Guid PersonId, [FromBody] DetailPersonDto personDto)
    {
        var updated = await service.Update(PersonId, personDto);
        if (!updated)
            return NotFound();
        return NoContent();
    }
}
